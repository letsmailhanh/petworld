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

        //Get danh sach user
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
    }
}
