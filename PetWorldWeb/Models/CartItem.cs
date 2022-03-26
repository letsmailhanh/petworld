using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace PetWorldWeb.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public CartItem()
        {

        }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
