using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using DataAccess.Repository;

namespace PetWorldWeb.Pages.Orders
{
    public class DetailsModel : BaseViewModel
    {
        private readonly DataAccess.Model.prn221_petworldContext _context;
        private readonly IOrderDetailRepository ordDetRepo;

        public List<OrderDetail> CartItems { get; set; } = new List<OrderDetail>();
        public double Total { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; } = 0;
        public Order Order { get; set; }

        public DetailsModel(DataAccess.Model.prn221_petworldContext context, [FromServices] IOrderDetailRepository ordDetRepo)
        {
            _context = context;
            this.ordDetRepo = ordDetRepo;
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Order =  _context.Orders.Include(o => o.User).FirstOrDefault(m => m.OrderId == OrderId);
            if (Order != null)
            {
                CartItems = ordDetRepo.GetOrderDetailListByOrder(Order).ToList();
                Total = (double)CartItems.Sum(item => item.Product.Price * item.Quantity);
            }
            else
            {
                Order = new Order();
            }
            base.OnPageHandlerExecuting(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
