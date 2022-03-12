using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    class ProductDAO
    {
        //---------------------------
        //Using ingleton pattern
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance;
            }
        }
        //Get product list
        public List<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var db = new prn221_petworldContext();
                products = db.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        //Get accessory list
        public List<Product> GetAccessoryList()
        {
            List<Product> accessories;
            try
            {
                var db = new prn221_petworldContext();
                var query = from p in db.Products
                            where p.IsPet == false
                            select p;
                accessories = query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accessories;
        }
        //Get pet list
        public List<Product> GetPetList()
        {
            List<Product> pets;
            try
            {
                var db = new prn221_petworldContext();
                var query = from p in db.Products
                            where p.IsPet == true
                            select p;
                pets = query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pets;
        }
        //Get product list by category ID
        public List<Product> GetProductListByCatID(int catID)
        {
            List<Product> products;
            try
            {
                var db = new prn221_petworldContext();
                var query = from p in db.Products
                            where p.CategoryId == catID
                            select p;
                products = query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
    }
}
