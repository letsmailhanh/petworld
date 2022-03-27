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
        [BindProperty (SupportsGet =true)]
        public string SearchTerm { get; set; } = "";
        public string SearchHandler { get; set; }
        public int PageSize { get; set; } = 6;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IList<Product> AllProducts { get; set; } = new List<Product>();
        public List<Product> Product { get; set; } = new List<Product>();
        public List<Product> GetPaginatedResult(IList<Product> products, int currentPage = 1, int pageSize = 10)
        {
            return products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public void OnGetSearch([FromServices] IProductRepository prodRepo)
        {
            ViewData["CategoryName"] = "Product";
            ViewData["SearchTerm"] = SearchTerm;
            if (SearchTerm == "" || SearchTerm == null)
            {
                AllProducts = prodRepo.GetProducts().OrderBy(p => p.ProductId).ToList();
            }
            else
            {
                AllProducts = prodRepo.GetProductsByName(SearchTerm).OrderBy(p => p.ProductId).ToList();
            }
            Count = AllProducts.Count;
            Product = GetPaginatedResult(AllProducts, CurrentPage, 6);
            SearchHandler = "Search";
        }

        public void OnGetOrderByNameAscending([FromServices] IProductRepository prodRepo)
        {
            ViewData["CategoryName"] = "Product";
            ViewData["SearchTerm"] = SearchTerm;
            if (SearchTerm == "" || SearchTerm == null)
            {
                AllProducts = prodRepo.GetProducts().OrderBy(p => p.ProductName).ToList();
            }
            else
            {
                AllProducts = prodRepo.GetProductsByName(SearchTerm).OrderBy(p => p.ProductName).ToList();
            }
            Count = AllProducts.Count;
            Product = GetPaginatedResult(AllProducts, CurrentPage, 6); 
            SearchHandler = "OrderByNameAscending";
        }

        public void OnGetOrderByPriceAscending([FromServices] IProductRepository prodRepo)
        {
            ViewData["CategoryName"] = "Product";
            ViewData["SearchTerm"] = SearchTerm;
            if (SearchTerm == "" || SearchTerm == null)
            {
                AllProducts = prodRepo.GetProducts().OrderBy(p => p.Price).ToList();
            }
            else
            {
                AllProducts = prodRepo.GetProductsByName(SearchTerm).OrderBy(p => p.Price).ToList();
            }
            Count = AllProducts.Count;
            Product = GetPaginatedResult(AllProducts, CurrentPage, 6);
            SearchHandler = "OrderByPriceAscending";
        }
        public void OnGetOrderByName([FromServices] IProductRepository prodRepo)
        {
            ViewData["CategoryName"] = "Product";
            ViewData["SearchTerm"] = SearchTerm;
            if (SearchTerm == "" || SearchTerm == null)
            {
                AllProducts = prodRepo.GetProducts().OrderByDescending(p => p.ProductName).ToList();
            }
            else
            {
                AllProducts = prodRepo.GetProductsByName(SearchTerm).OrderByDescending(p => p.ProductName).ToList();
            }
            Count = AllProducts.Count;
            Product = GetPaginatedResult(AllProducts, CurrentPage, 6);
            SearchHandler = "OrderByNameDescending";
        }

        public void OnGetOrderByPrice([FromServices] IProductRepository prodRepo)
        {
            ViewData["CategoryName"] = "Product";
            ViewData["SearchTerm"] = SearchTerm;
            if (SearchTerm == "" || SearchTerm == null)
            {
                AllProducts = prodRepo.GetProducts().OrderByDescending(p => p.Price).ToList();
            }
            else
            {
                AllProducts = prodRepo.GetProductsByName(SearchTerm).OrderByDescending(p => p.Price).ToList();
            }
            Count = AllProducts.Count;
            Product = GetPaginatedResult(AllProducts, CurrentPage, 6);
            SearchHandler = "OrderByPriceDescending";
        }
    }
}
