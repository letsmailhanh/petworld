using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetWorldWeb.Pages.Orders
{
    public class ListModel : BaseViewModel
    {
        [BindProperty(SupportsGet = true)]
        public List<Order> Orders { get; set; } = new List<Order>();
        public void OnGet([FromServices] IUserRepository userRepo, [FromServices] IOrderRepository orderRepo)
        {
            User user = userRepo.GetUserByUsername(CurUser);
            if (user == null) return;
            List<Order> orders = orderRepo.GetOrderListOfUser(user).ToList();
            if (orders != null)
            {
                Orders = orders;
            }
        }
    }
}
