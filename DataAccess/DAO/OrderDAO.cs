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
    }
}
