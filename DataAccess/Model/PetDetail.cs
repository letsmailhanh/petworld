using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
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

        public PetDetail(int petId, int productId, string petName, double weight, bool vaccinated, bool gender, double age, bool sterilized, bool isRescued)
        {
            PetId = petId;
            ProductId = productId;
            PetName = petName;
            Weight = weight;
            Vaccinated = vaccinated;
            Gender = gender;
            Age = age;
            Sterilized = sterilized;
            IsRescued = isRescued;
        }
        public PetDetail(int productId, string petName, double weight, bool vaccinated, bool gender, double age, bool sterilized, bool isRescued)
        {
            ProductId = productId;
            PetName = petName;
            Weight = weight;
            Vaccinated = vaccinated;
            Gender = gender;
            Age = age;
            Sterilized = sterilized;
            IsRescued = isRescued;
        }
    }
}
