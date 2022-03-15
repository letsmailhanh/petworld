using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IPetDetailRepository
    {
        PetDetail GetPetDetailByProductID(int pID);
        void AddPetDetail(PetDetail pd);
        void UpdatePetDetail(PetDetail pd);
        void DeletePetDetaail(PetDetail pd);
    }
}
