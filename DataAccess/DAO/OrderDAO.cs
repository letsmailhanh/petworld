using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    class OrderDAO
    {
        //---------------------------
        //Using Singleton Pattern
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new Object();

        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                }
                return instance;
            }
        }

        //Get danh sach order
        public IEnumerable<Order> GetOrderList()
        {
            List<Order> orders;
            try
            {
                var db = new prn221_petworldContext();
                orders = db.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orders;
        }
        //Get danh sach Order theo status
        public IEnumerable<Order> GetOrderListByStatus(string statusName)
        {
            List<Order> orders;
            try
            {
                int status;
                switch (statusName)
                {
                    case "Unconfirmed": status = 0; break;
                    case "Confirmed": status = 1; break;
                    case "Shipping": status = 2; break;
                    case "Shipped": status = 3; break;
                    default: status = -1; break;
                }
                var db = new prn221_petworldContext();
                //var query = from o in db.Orders
                //            where o.Status == status
                //            select o;
                orders = db.Orders.Where(o => o.Status == status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        //Get order list 
        public IEnumerable<Order> GetOrderListInPeriod(DateTime fromDate, DateTime toDate)
        {
            List<Order> orders = null;
            try
            {
                var db = new prn221_petworldContext();
                orders = db.Orders.Where(o => o.OrderDate <= toDate && o.OrderDate >= fromDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
    }
}
