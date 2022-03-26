using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    class OrderDetailDAO
    {
        //---------------------------
        //Using Singleton Pattern
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new Object();

        private OrderDetailDAO() { }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                }
                return instance;
            }
        }

        //Get danh sach order
        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var db = new prn221_petworldContext();
                orderDetails = db.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        //Get danh sach order detail theo order
        public IEnumerable<OrderDetail> GetOrderDetailByOrder(Order o)
        {
            List<OrderDetail> orderDetails;
            try
            {
                var db = new prn221_petworldContext();
                orderDetails = db.OrderDetails.Where(od => od.OrderId == o.OrderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        //Get list product theo order detail
        public IEnumerable<Product> GetProductListByOrder(Order o)
        {
            List<Product> result = new List<Product>();
            try
            {
                var db = new prn221_petworldContext();
                List<OrderDetail> orderDetails = db.OrderDetails.Where(od => od.OrderId == o.OrderId).ToList();
                List<Product> products = db.Products.ToList();
                foreach (OrderDetail od in orderDetails)
                {
                    foreach (Product p in products)
                    {
                        if(od.ProductId == p.ProductId)
                        {
                            result.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
