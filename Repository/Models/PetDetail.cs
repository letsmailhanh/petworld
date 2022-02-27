using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class PetDetail
    {
        public int PetId { get; set; }
        public int ProductId { get; set; }
        public string PetName { get; set; }
        public double Weight { get; set; }
        public bool Vaccinated { get; set; }
        public bool Gender { get; set; }
        public double Age { get; set; }
        public bool Sterilized { get; set; }
        public bool IsRescued { get; set; }

        public virtual Product Product { get; set; }
    }
}
