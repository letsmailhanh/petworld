using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Model;
using PetWorldWeb.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace PetWorldWeb.Pages.Orders
{
    public class CreateModel : BaseViewModel
    {
        private readonly DataAccess.Model.prn221_petworldContext _context;
        private IUserRepository userRepo;
        [BindProperty(SupportsGet = true)]
        public List<string> Cart { get; set; } = new List<string>();
        [BindProperty(SupportsGet = true)]
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        [BindProperty(SupportsGet =true)]
        public User _User { get; set; } = new User();
        public double Total { get; set; }
        [BindProperty]
        public Order Order { get; set; }

        public CreateModel(DataAccess.Model.prn221_petworldContext context, [FromServices] IUserRepository userRepo)
        {
            _context = context;
            this.userRepo = userRepo;
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            User user = userRepo.GetUserByUsername(CurUser);
            if (user != null)
            {
                _User = user;
            }
            base.OnPageHandlerExecuting(context);
        }

        public IActionResult OnGet()
        {
            LoadInfo();
            UpdateCart();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost([FromServices] IOrderRepository ordRepo, [FromServices] IOrderDetailRepository ordDetRepo, [FromServices] IProductRepository prodRepo)
        {
            LoadInfo();
            UpdateCart();
            String message = "";
            bool invalid = false;
            foreach (CartItem item in CartItems)
            {
                Product product = prodRepo.GetProductByID(item.Product.ProductId);
                if (product.UnitsInStock <= 0)
                {
                    message += "Product " + item.Product.ProductName + " Is No Longer Available, And Has Been Removed From Your Cart.\n";
                    RemoveFromCart(item.Product.ProductId);
                    invalid = true;
                    continue;
                }
                if (product.UnitsInStock - item.Quantity < 0)
                {
                    message += "Product " + item.Product.ProductName + " Don't have enough Stock, And Has Been Update From Your Cart.\n";
                    Cart[ExistsInCart(Cart, product.ProductId)] = "Item:" + item.Product.ProductId.ToString() + "=" + (product.UnitsInStock).ToString();
                    invalid = true;
                }
            }
            if (invalid)
            {
                ViewData["message"] = message;
                UpdateCart();
                UpdateCookies();
                return Page();
            }
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Invalid Info";
                return Page();
            }
            if (CartItems.Count <= 0)
            {
                ViewData["message"] = "Empty Cart";
                return Page();
            }
            if (_context.Users.Where(u => u.UserId == _User.UserId).FirstOrDefault() == null)
            {
                string username = "";
                while (true)
                {
                    username = RandStr();
                    if (userRepo.GetUserByUsername(username) == null) break;
                }
                _User.UserName = username;
                _User.Password = username;
                _User.Role = "customer";
                userRepo.AddUser(_User);
                _User = userRepo.GetUserByUsername(username); 
            }
            Order.UserId = _User.UserId;
            Order.Freight = 100000;
            Order.Status = 0;
            Order = ordRepo.AddOrder(Order);
            foreach(CartItem item in CartItems)
            {
                Product product = prodRepo.GetProductByID(item.Product.ProductId);
                OrderDetail ordDetail = new OrderDetail();
                ordDetail.OrderId = Order.OrderId;
                ordDetail.ProductId = item.Product.ProductId;
                ordDetail.Quantity = item.Quantity;
                ordDetail.Price = item.Product.Price;
                ordDetRepo.AddOrderDetail(ordDetail);
                product.UnitsInStock = product.UnitsInStock - ordDetail.Quantity;
                prodRepo.UpdateProduct(product);
            }
            Response.Cookies.Delete("Cart");
            Response.Cookies.Delete("CartItemCount");
            return Redirect("/Orders/Details?orderid=" + Order.OrderId);
        }
        private int ExistsInCart(List<string> cart, int id)
        {
            return cart.FindIndex(i => i.Contains("Item:" + id.ToString() + "="));
        }
        private void RemoveFromCart(int id)
        {
            Cart.RemoveAt(ExistsInCart(Cart, id));
        }
        private void LoadInfo()
        {
            string cartCookies = Request.Cookies["Cart"] != null ? Request.Cookies["Cart"].Replace(" ", "") : "";
            Cart = cartCookies.Split(";").ToList();
            UpdateCart();
        }
        private void UpdateCookies()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            Response.Cookies.Delete("Cart");
            Response.Cookies.Append("Cart", string.Join(";", Cart), cookieOptions);
            Response.Cookies.Delete("CartItemCount");
            Response.Cookies.Append("CartItemCount", CartItems.Sum(i => i.Quantity).ToString(), cookieOptions);
        }
        private void UpdateCart()
        {
            CartItems.Clear();
            foreach (string item in Cart)
            {
                if (item == "") continue;
                int prodId = int.Parse(item.Split("=")[0].Split(":")[1]);
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
            Total = (double)CartItems.Sum(item => item.Product.Price * item.Quantity);
            ViewData["CartItems"] = CartItems;
            ViewData["Total"] = (int)Total;
            ViewData["CartItemCount"] = CartItems.Sum(i => i.Quantity).ToString();
        }
        private string RandStr()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
