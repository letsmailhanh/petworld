using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetWorldWeb.Models;

namespace PetWorldWeb.Pages.Orders
{
    public class TrackingModel : BaseViewModel
    {
        public Order Order { get; set; } = new Order();
        [BindProperty(SupportsGet = true)]
        public string OrderId { get; set; } = "0";
        public double Total { get; set; } = 0;
        public List<OrderDetail> CartItems { get; set; } = new List<OrderDetail>();
        public void OnGet([FromServices] IOrderRepository ordRepo, [FromServices] IOrderDetailRepository ordDetRepo)
        {
            try
            {
                int orderid = Int32.Parse(OrderId);
                Order order = ordRepo.GetOrderById(orderid);
                if (order != null)
                {
                    Order = order;
                    CartItems = ordDetRepo.GetOrderDetailListByOrder(order).ToList();
                    Total = (double)CartItems.Sum(item => item.Product.Price * item.Quantity);
                }
                else
                {
                    if (Request.QueryString.HasValue)
                        ViewData["message"] = $"Order {OrderId} Not Exist!";
                }
            }
            catch (Exception)
            {
                ViewData["message"] = "Invalid Order Id!";
            }
        }
    }
}
