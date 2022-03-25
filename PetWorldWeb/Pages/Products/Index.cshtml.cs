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
    public class IndexModel : BaseViewModel
    {
        private readonly prn221_petworldContext _context;

        public IndexModel(prn221_petworldContext context)
        {
            _context = context;
        }


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; } = 0;
        public int Count { get; set; }
        public int PageSize { get; set; } = 6;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public IList<Product> AllProducts { get;set; }
        public List<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                ViewData["CategoryName"] = "Product";
                AllProducts = await _context.Products.ToListAsync();
                Count = AllProducts.Count;
                Product = await GetPaginatedResult(CurrentPage, PageSize);
            }
            else
            {
                ViewData["CategoryName"] = category.Title;
                AllProducts = await _context.Products.Where(p => p.CategoryId == CategoryId).ToListAsync();
                Count = AllProducts.Count;
                Product = await GetPaginatedResult(CurrentPage, PageSize);
            }
        }
        public async Task<List<Product>> GetPaginatedResult(int currentPage, int pageSize = 10, int category = 0)
        {
            if (category == 0)
            {
                var data = await _context.Products.Include(p => p.Category).ToListAsync();
                return data.OrderBy(d => d.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                var data = await _context.Products.Where(p => p.CategoryId == category).Include(p => p.Category).ToListAsync();
                return data.OrderBy(d => d.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
