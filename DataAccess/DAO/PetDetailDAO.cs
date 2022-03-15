using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    class PetDetailDAO
    {
        //---------------------------
        //Using ingleton pattern
        private static PetDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private PetDetailDAO() { }
        public static PetDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PetDetailDAO();
                    }
                }
                return instance;
            }
        }
        //Get pet detail by product id 
        public PetDetail GetPetDetailByProductID(int pID)
        {
            PetDetail pd = null;
            try
            {
                var db = new prn221_petworldContext();
                pd = db.PetDetails.SingleOrDefault(pd => pd.ProductId == pID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pd;
        }
        //Add pet detail
        public void AddPetDetail(PetDetail pd)
        {
            try
            {
                PetDetail _pd = GetPetDetailByProductID(pd.ProductId);
                if (_pd == null)
                {
                    var db = new prn221_petworldContext();
                    db.PetDetails.Add(pd);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Detail da ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update pet detail
        public void UpdatePetDetail(PetDetail pd)
        {
            try
            {
                PetDetail _pd = GetPetDetailByProductID(pd.ProductId);
                if (_pd != null)
                {
                    var db = new prn221_petworldContext();
                    db.Entry<PetDetail>(pd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("San pham khong ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete pet detail
        public void DeletePetDetail(PetDetail pd)
        {
            try
            {
                PetDetail _pd = GetPetDetailByProductID(pd.ProductId);
                if (_pd != null)
                {
                    var db = new prn221_petworldContext();
                    db.PetDetails.Remove(pd);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("San pham khong ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
