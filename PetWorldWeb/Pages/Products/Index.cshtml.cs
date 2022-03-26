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
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; } = "all";
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
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = "Product";
                    AllProducts = await _context.Products.ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    AllProducts = await _context.Products.Where(p => p.IsPet == true).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = "Accessory";
                    AllProducts = await _context.Products.Where(p => p.IsPet == false).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            else
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.CategoryId == CategoryId).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.CategoryId == CategoryId).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            Product = GetPaginatedResult(AllProducts, CurrentPage, PageSize);
        }
        public List<Product> GetPaginatedResult(IList<Product> products, int currentPage = 1, int pageSize = 10)
        {
            return products.OrderBy(d => d.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
