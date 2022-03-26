using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetWorldWeb.Helpers;
using PetWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetWorldWeb.Pages.Orders
{
    public class CartModel : BaseViewModel
    {
        private readonly prn221_petworldContext _context;

        public List<string> Cart { get; set; } = new List<string>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public double Total { get; set; }
        public CartModel(DataAccess.Model.prn221_petworldContext context)
        {
            _context = context;
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            string cartCookies = Request.Cookies["Cart"] != null ? Request.Cookies["Cart"].Replace(" ", null) : "";
            Cart = cartCookies.Split(";").ToList();
            Cart.Remove("");
            UpdateCart();
            base.OnPageHandlerSelected(context);
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            UpdateCart(); 
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            Response.Cookies.Delete("Cart");
            Response.Cookies.Append("Cart", string.Join(";", Cart), cookieOptions);
            Response.Cookies.Delete("CartItemCount");
            Response.Cookies.Append("CartItemCount", CartItems.Sum(i => i.Quantity).ToString(), cookieOptions);
            base.OnPageHandlerExecuted(context);
        }

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
                CartItem cartItem = CartItems.Find(c => c.Product.ProductId == id);
                if (cartItem != null)
                {
                    if (int.Parse(item[1]) + 1 <= cartItem.Product.UnitsInStock)
                        Cart[cartPos] = id.ToString() + "=" + (int.Parse(item[1]) + 1).ToString();
                    else
                    {
                        Cart[cartPos] = id.ToString() + "=" + (cartItem.Product.UnitsInStock).ToString();
                    }
                }
            }
            else
            {
                Cart.Add(id.ToString() + "=1");
            }

            return Redirect(Request.Headers["Referer"].ToString());
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
            foreach (string item in Cart)
            {
                if (item == "") continue;
                int prodId = int.Parse(item.Split("=")[0]);
                int quantity = int.Parse(item.Split("=")[1]);
                CartItems.Add(
                    new CartItem
                    {
                        Product = _context.Products
                        .Include(p => p.Category)
                        .Where(p => p.ProductId == prodId).FirstOrDefault(),
                        Quantity = quantity
                    }
                );
            }
        }
        public IActionResult OnGetDelete(int id)
        {
            RemoveFromCart(id);
            return RedirectToPage("Cart");
        }
        public IActionResult OnPostUpdate(int id, int quantity, [FromServices] IProductRepository productRepo)
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
            return RedirectToPage("Cart");
        }
    }
}
