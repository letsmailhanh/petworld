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
        public static Dictionary<bool, string> Gender = 
            new Dictionary<bool, string>
            {
                {true, "Male" },
                {false, "Female" }
            };
        public static Dictionary<bool, string> Vaccinated = 
            new Dictionary<bool, string>
            {
                {true, "Vaccinated" },
                {false, "Not Vaccinated" }
            };
        public static Dictionary<bool, string> Sterilized = 
            new Dictionary<bool, string>
            {
                {true, "Sterilized" },
                {false, "Not Sterilized" }
            };
        public static Dictionary<bool, string> Rescued = 
            new Dictionary<bool, string>
            {
                {true, "Rescued" },
                {false, "Original" }
            };
    }
}
