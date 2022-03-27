 using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        //Get product list by name
        public List<Product> GetProductListByName(string key)
        {
            List<Product> products;
            try
            {
                var db = new prn221_petworldContext();
                var query = from p in db.Products
                            where p.ProductName.ToLower().Contains(key.ToLower())
                            select p;
                products = query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        //Get product by id
        public Product GetProductByID(int id)
        {
            Product p = null;
            try
            {
                var db = new prn221_petworldContext();
                p = db.Products.Include(p => p.PetDetail)
                    .Include(p => p.Category)
                    .SingleOrDefault(p => p.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        //add new product
        public void AddProduct(Product p)
        {
            try
            {
                Product _p = GetProductByID(p.ProductId);
                if(_p == null)
                {
                    var db = new prn221_petworldContext();
                    db.Products.Add(p);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("San pham da ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //update product
        public void UpdateProduct(Product p)
        {
            try
            {
                Product _p = GetProductByID(p.ProductId);
                if(_p != null)
                {
                    var db = new prn221_petworldContext();
                    db.Entry<Product>(p).State = EntityState.Modified;
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
        //delete product
        public void DeleteProduct(Product p)
        {
            try
            {
                Product _p = GetProductByID(p.ProductId);
                if (_p != null)
                {
                    var db = new prn221_petworldContext();
                    db.Products.Remove(p);

                    //delete pet detail
                    if(p.IsPet == true)
                    {
                        PetDetailRepository petRepo = new PetDetailRepository();
                        PetDetail pd = petRepo.GetPetDetailByProductID(p.ProductId);
                        db.PetDetails.Remove(pd);
                    }
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
