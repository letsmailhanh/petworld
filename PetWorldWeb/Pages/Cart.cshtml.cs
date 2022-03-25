using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetWorldWeb.Helpers;
using PetWorldWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetWorldWeb.Pages
{
    public class CartModel : BaseViewModel
    {
        private readonly prn221_petworldContext _context;

        public List<string> Cart { get; set; } = new List<string>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public CartModel(DataAccess.Model.prn221_petworldContext context)
        {
            _context = context;
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            string cartCookies = Request.Cookies["Cart"] != null ? Request.Cookies["Cart"].Replace(" ", "") : "";
            Cart = cartCookies.Split(";").ToList();
            if (Cart[0] != "")
            {
                foreach (string item in Cart)
                {
                    int prodId = int.Parse(item.Split("=")[0]);
                    int quantity = int.Parse(item.Split("=")[1]);
                    CartItems.Add(
                        new CartItem
                        {
                            Product = _context.Products.Where(p => p.ProductId == prodId).FirstOrDefault(),
                            Quantity = quantity
                        }
                    );
                }
            }
            base.OnPageHandlerSelected(context);
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            Response.Cookies.Delete("Cart");
            Response.Cookies.Append("Cart", string.Join(";", Cart));
            Response.Cookies.Delete("CartItemCount");
            Response.Cookies.Append("CartItemCount", CartItems.Sum(i => i.Quantity).ToString());
            base.OnPageHandlerExecuted(context);
        }

        public double Total { get; set; }

        public void OnGet()
        {
            if (Cart != null)
            {
                UpdateCart();
                Total = (double)CartItems.Sum(item => item.Product.Price * item.Quantity);
            }
        }

        public IActionResult OnGetAddToCart(int id, [FromServices] IProductRepository productRepo)
        {
            Product product = productRepo.GetProductByID(id);
            if (product == null)
            {
                return NotFound("Item does not exist.");
            }

            int cartPos = ExistsInCart(Cart, id);
            if (cartPos > -1)
            {
                string[] item = Cart[cartPos].Split("=");
                Cart[cartPos] = id.ToString() + "=" + (int.Parse(item[1]) + 1).ToString();
            }
            else
            {
                Cart.Add(id.ToString() + "=1");
            }

            return RedirectToPage("Cart");
            //if (id <= 0) return NotFound();
            //Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            //CartItem item = new(productRepo.GetProductByID(id), 1);
            //if (item == null)
            //{
            //    return NotFound("Item does not exist.");
            //}
            //if (Cart == null)
            //{
            //    Cart = new List<CartItem>
            //    {
            //        item
            //    };
            //    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            //}
            //else
            //{
            //    int index = ExistsInCart(Cart, id);
            //    if (index == -1)
            //    {
            //        Cart.Add(item);
            //    }
            //    else
            //    {
            //        Cart[index].Quantity++;
            //    }
            //    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            //}
        }
        private int ExistsInCart(List<string> cart, int id)
        {
            return cart.FindIndex(i => i.Contains(id.ToString() + "="));
        }
        private void RemoveFromCart(int id)
        {
            Cart.RemoveAt(ExistsInCart(Cart, id));
        }
        private void UpdateCart()
        {
            CartItems.Clear();
            if (Cart[0] != "")
            {
                foreach (string item in Cart)
                {
                    int prodId = int.Parse(item.Split("=")[0]);
                    int quantity = int.Parse(item.Split("=")[1]);
                    CartItems.Add(
                        new CartItem
                        {
                            Product = _context.Products.Where(p => p.ProductId == prodId).FirstOrDefault(),
                            Quantity = quantity
                        }
                    );
                }
            }
        }
        public IActionResult OnGetDelete(int id)
        {
            RemoveFromCart(id);

            //Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            //int index = ExistsInCart(Cart, id);
            //Cart.RemoveAt(index);
            //SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);

            return RedirectToPage("Cart");
        }
        public IActionResult OnGetUpdate(int id, int quantity, [FromServices] IProductRepository productRepo)
        {
            Product product = productRepo.GetProductByID(id);
            if (product == null)
            {
                return NotFound("Item does not exist.");
            }

            int cartPos = ExistsInCart(Cart, id);
            if (cartPos > -1)
            {
                if (quantity == 0)
                {
                    RemoveFromCart(id);
                }
                else
                {
                    Cart[cartPos] = id.ToString() + "=" + quantity.ToString();
                }
            }
            //Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            //for (var i = 0; i < Cart.Count; i++)
            //{
            //    Cart[i].Quantity = quantities[i];
            //}
            //SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            return RedirectToPage("Cart");
        }
    }
}
