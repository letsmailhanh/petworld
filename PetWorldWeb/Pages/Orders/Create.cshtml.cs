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

namespace PetWorldWeb.Pages.Orders
{
    public class CreateModel : BaseViewModel
    {
        private readonly DataAccess.Model.prn221_petworldContext _context;
        private IUserRepository userRepo;
        public List<string> Cart { get; set; } = new List<string>();
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
        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            string cartCookies = Request.Cookies["Cart"] != null ? Request.Cookies["Cart"].Replace(" ", "") : "";
            Cart = cartCookies.Split(";").ToList();
            UpdateCart();

            base.OnPageHandlerSelected(context);
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
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost([FromServices] IOrderRepository ordRepo, [FromServices] IOrderDetailRepository ordDetRepo)
        {
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
                OrderDetail ordDetail = new OrderDetail();
                ordDetail.OrderId = Order.OrderId;
                ordDetail.ProductId = item.Product.ProductId;
                ordDetail.Quantity = item.Quantity;
                ordDetail.Price = item.Product.Price;
                ordDetRepo.AddOrderDetail(ordDetail);
            }
            Response.Cookies.Delete("Cart");
            Response.Cookies.Delete("CartItemCount");
            return RedirectToPage("./Index");
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
            Total = (double)CartItems.Sum(item => item.Product.Price * item.Quantity);
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
