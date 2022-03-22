using System;
using System.Collections.Generic;

#nullable disable

namespace PRN221_GroupProject_PetWorldWeb.Models
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
    }
}
