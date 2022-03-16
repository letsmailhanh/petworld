using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public bool IsPet { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual PetDetail PetDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Product(int productId, string productName, int categoryId, bool isPet, decimal price, int unitsInStock, string image)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            IsPet = isPet;
            Price = price;
            UnitsInStock = unitsInStock;
            Image = image;
        }

        public Product(string productName, int categoryId, bool isPet, decimal price, int unitsInStock, string image)
        {
            ProductName = productName;
            CategoryId = categoryId;
            IsPet = isPet;
            Price = price;
            UnitsInStock = unitsInStock;
            Image = image;
        }
    }
}
