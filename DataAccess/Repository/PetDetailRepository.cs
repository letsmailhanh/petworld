using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PetDetailRepository : IPetDetailRepository
    {
        public void AddPetDetail(PetDetail pd) => PetDetailDAO.Instance.AddPetDetail(pd);

        public void DeletePetDetaail(PetDetail pd) => PetDetailDAO.Instance.DeletePetDetail(pd);

        public PetDetail GetPetDetailByProductID(int pID) => PetDetailDAO.Instance.GetPetDetailByProductID(pID);

        public void UpdatePetDetail(PetDetail pd) => PetDetailDAO.Instance.UpdatePetDetail(pd);
    }
}
