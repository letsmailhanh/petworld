using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWorldWeb.Models
{
    public class Constants
    {
        public static Dictionary<int, string> OrderStatus =
            new Dictionary<int, string>
            {
                {0, "Not Confirmed" },
                {1, "Confirmed" },
                {2, "Shipping" },
                {3, "Shipped" }
            };
    }
}
