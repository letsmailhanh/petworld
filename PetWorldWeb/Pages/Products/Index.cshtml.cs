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
        public List<string> CheckedList { get; set; } = new List<string>();
        public string SearchHandler { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; } = 6;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public IList<Product> AllProducts { get; set; } = new List<Product>();
        public List<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = "Product";
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = "Accessory";
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            else
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            Product = GetPaginatedResult(AllProducts, CurrentPage, PageSize); 
            SearchHandler = "";
        }
        public async Task OnGetOrderByPriceAscendingAsync()
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = "Product";
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderBy(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.UnitsInStock > 0).OrderBy(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = "Accessory";
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.UnitsInStock > 0).OrderBy(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            else
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderBy(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            Product = GetPaginatedResult(AllProducts, CurrentPage, PageSize);
            SearchHandler = "OrderByPriceAscending";
        }
        public async Task OnGetOrderByNameAscendingAsync()
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = "Product";
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderBy(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.UnitsInStock > 0).OrderBy(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = "Accessory";
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.UnitsInStock > 0).OrderBy(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            else
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderBy(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            Product = GetPaginatedResult(AllProducts, CurrentPage, PageSize);
            SearchHandler = "OrderByNameAscending";
        }
        public async Task OnGetOrderByPriceDescendingAsync()
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = "Product";
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderByDescending(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.UnitsInStock > 0).OrderByDescending(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = "Accessory";
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.UnitsInStock > 0).OrderByDescending(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            else
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderByDescending(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderByDescending(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderByDescending(p => p.Price).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            Product = GetPaginatedResult(AllProducts, CurrentPage, PageSize);
            SearchHandler = "OrderByPriceDescending";
        }
        public async Task OnGetOrderByNameDescendingAsync()
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = "Product";
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderByDescending(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.UnitsInStock > 0).OrderByDescending(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = "Accessory";
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.UnitsInStock > 0).OrderByDescending(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            else
            {
                if (Type.Equals("all"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.UnitsInStock > 0).OrderByDescending(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == true && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderByDescending(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
                else
                {
                    ViewData["CategoryName"] = category.Title;
                    AllProducts = await _context.Products.Where(p => p.IsPet == false && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderByDescending(p => p.ProductName).ToListAsync();
                    Count = AllProducts.Count;
                }
            }
            Product = GetPaginatedResult(AllProducts, CurrentPage, PageSize);
            SearchHandler = "OrderByNameDescending";
        }
        public async Task OnGetCheckboxAsync(List<string> checkedList)
        {
            Category category = _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault();
            if (category == null || CategoryId == 0)
            {
                List<Product> allProducts = await _context.Products.Include(p => p.PetDetail).Where(p => p.IsPet == true && p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = "Pet";
                    if (!checkedList.Contains("Male"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Gender == true);
                        checkedList.Add("Female");
                    }
                    if (!checkedList.Contains("Female"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Gender == false);
                    }
                    if (!checkedList.Contains("Vaccinated"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Vaccinated == true);
                    }
                    if (!checkedList.Contains("Sterilized"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Sterilized == true);
                    }
                    if (!checkedList.Contains("Rescued"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.IsRescued == true);
                    }
                    Count = allProducts.Count;
                    Product = GetPaginatedResult(allProducts, CurrentPage, PageSize);
                }
            }
            else
            {
                if (Type.Equals("pet"))
                {
                    ViewData["CategoryName"] = category.Title;
                    List<Product> allProducts = await _context.Products.Include(p => p.PetDetail).Where(p => p.IsPet == true && p.CategoryId == CategoryId && p.UnitsInStock > 0).OrderBy(p => p.ProductId).ToListAsync();
                    ViewData["CategoryName"] = "Pet";
                    if (!checkedList.Contains("Male"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Gender == true);
                    }
                    if (!checkedList.Contains("Female"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Gender == false);
                    }
                    if (!checkedList.Contains("Vaccinated"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Vaccinated == true);
                    }
                    if (!checkedList.Contains("Sterilized"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.Sterilized == true);
                    }
                    if (!checkedList.Contains("Rescued"))
                    {
                        allProducts.RemoveAll(p => p.PetDetail.IsRescued == true);
                    }
                    Count = allProducts.Count;
                    Product = GetPaginatedResult(allProducts, CurrentPage, PageSize);
                }
            }
            CheckedList = checkedList;
            SearchHandler = "Checkbox";
        }
        public List<Product> GetPaginatedResult(IList<Product> products, int currentPage = 1, int pageSize = 10)
        {
            return products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
