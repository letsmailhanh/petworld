using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
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

        public Category(string title)
        {
            Title = title;
        }
    }
}
