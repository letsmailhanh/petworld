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
    public class DetailsModel : BaseViewModel
    {
        private readonly prn221_petworldContext _context;

        public DetailsModel(prn221_petworldContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public IActionResult OnGet(int? id, [FromServices] IProductRepository prodRepo)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = prodRepo.GetProductByID((int)id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
