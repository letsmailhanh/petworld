using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using DataAccess.Repository;

namespace PetWorldWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly prn221_petworldContext _context;

        public IndexModel(prn221_petworldContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync([FromServices] IProductRepository productRepo)
        {
            Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
        }
    }
}
