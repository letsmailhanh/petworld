using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_GroupProject_PetWorldWeb.Models;

namespace PRN221_GroupProject_PetWorldWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_GroupProject_PetWorldWeb.Models.prn221_petworldContext _context;

        public IndexModel(PRN221_GroupProject_PetWorldWeb.Models.prn221_petworldContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
        }
    }
}
