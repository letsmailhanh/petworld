using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool? IsPet { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
