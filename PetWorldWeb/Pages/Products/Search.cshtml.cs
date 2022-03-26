using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PetWorldWeb.Pages.Products
{
    public class SearchModel : BaseViewModel
    {
        private readonly prn221_petworldContext _context;

        public SearchModel(prn221_petworldContext context)
        {
            _context = context;
        }
        public int Count { get; set; }
        [BindProperty (SupportsGet =true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IList<Product> AllProducts { get; set; } = new List<Product>();
        public List<Product> Product { get; set; } = new List<Product>();
        public List<Product> GetPaginatedResult(IList<Product> products, int currentPage = 1, int pageSize = 10)
        {
            return products.OrderBy(d => d.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public void OnGetSearch([FromServices] IProductRepository prodRepo, string searchterm = "")
        {
            ViewData["CategoryName"] = "Product";
            ViewData["SearchTerm"] = searchterm;
            if (searchterm == "" || searchterm == null)
            {
                AllProducts = prodRepo.GetProducts().ToList();
            }
            else
            {
                AllProducts = prodRepo.GetProductsByName(searchterm).ToList();
            }
            Count = AllProducts.Count;
            Product = GetPaginatedResult(AllProducts, CurrentPage, 6);
        }
    }
}
