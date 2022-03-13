using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    class CategoryDAO
    {
        //---------------------------
        //Using Singleton Pattern
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new Object();

        private CategoryDAO() { }

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                }
                return instance;
            }
        }

        //Get danh sach category
        public IEnumerable<Category> GetCategoryList()
        {
            List<Category> categories;
            try
            {
                var db = new prn221_petworldContext();
                categories = db.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        //Get danh sach pet category
        public IEnumerable<Category> GetPetCategory()
        {
            List<Category> categories;
            try
            {
                var db = new prn221_petworldContext();
                var query = from c in db.Categories
                            where c.IsPet == true
                            select c;
                categories = query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            return categories;
        }

        //Get danh sach accessory category
        public IEnumerable<Category> GetAccessoryCategory()
        {
            List<Category> categories;
            try
            {
                var db = new prn221_petworldContext();
                var query = from c in db.Categories
                            where c.IsPet == false
                            select c;
                categories = query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
    }
}
