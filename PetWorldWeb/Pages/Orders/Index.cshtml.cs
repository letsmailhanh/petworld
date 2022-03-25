using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;

namespace PetWorldWeb.Pages.Orders
{
    public class IndexModel : BaseViewModel
    {
        private readonly DataAccess.Model.prn221_petworldContext _context;

        public IndexModel(DataAccess.Model.prn221_petworldContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.User).ToListAsync();
        }
    }
}
