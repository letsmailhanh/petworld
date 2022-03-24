using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetWorldWeb.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace PetWorldWeb.Pages
{
    public class CartModel : PageModel
    {
        IProductRepository productRepo;
        private readonly DataAccess.Model.prn221_petworldContext _context;

        public List<CartItem> Cart { get; set; }
        public CartModel(DataAccess.Model.prn221_petworldContext context, IProductRepository productRepository)
        {
            _context = context;
            productRepo = productRepository;
        }


        public double Total { get; set; }

        public void OnGet()
        {
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (Cart != null)
            {
                Total = (double)Cart.Sum(item => item.Product.Price * item.Quantity);
            }
            else
            {
                Cart = new List<CartItem>();
            }
        }

        public IActionResult OnGetAddToCart(int id)
        {
            //if (id <= 0) return NotFound();
            var product = new Product();
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            CartItem item = new(productRepo.GetProductByID(id), 1);
            if (item == null)
            {
                return NotFound("Item does not exist.");
            }
            if (Cart == null)
            {
                Cart = new List<CartItem>
                {
                    item
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            }
            else
            {
                int index = ExistsInCart(Cart, id);
                if (index == -1)
                {
                    Cart.Add(item);
                }
                else
                {
                    Cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            }
            return RedirectToPage("Cart");
        }
        private int ExistsInCart(List<CartItem> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult OnGetDelete(int id)
        {
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = ExistsInCart(Cart, id);
            Cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            return RedirectToPage("Cart");
        }
        public IActionResult OnPostUpdate(int[] quantities)
        {
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (var i = 0; i < Cart.Count; i++)
            {
                Cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            return RedirectToPage("Cart");
        }
    }
}
