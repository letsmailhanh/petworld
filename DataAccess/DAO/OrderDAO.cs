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

        public int GetTotalOrderADate(DateTime date)
        {
            int total = 0;
            var db = new prn221_petworldContext();
            var query = from o in db.Orders
                        where o.OrderDate == date
                        select o;
            total = query.ToList().Count;
            return total;
        }

        public decimal CalculateOrderRevenue(Order o)
        {
            decimal total = 0;

            var db = new prn221_petworldContext();
            List<OrderDetail> orderDetails = db.OrderDetails.Where(od => od.OrderId == o.OrderId).ToList();
            foreach (OrderDetail od in orderDetails)
            {
                total += od.Price * od.Quantity;
            }
            total += o.Freight;

            return total;
        }
        public decimal GetTotalRevenueOrderADate(DateTime date)
        {
            decimal total = 0;
            var db = new prn221_petworldContext();
            var query = from o in db.Orders
                        where o.ShippedDate == date
                        select o;
            foreach (Order o in query)
            {
                total += CalculateOrderRevenue(o);
            }
            return total;
        }

        public int[] GetCurrentWeekNumberOrder()
        {
            int[] result = new int[7];
            int num; 

            DateTime dt = DateTime.Today;

            if (dt.DayOfWeek == DayOfWeek.Monday) num = 0;
            else if (dt.DayOfWeek == DayOfWeek.Tuesday) num = 1;
            else if (dt.DayOfWeek == DayOfWeek.Wednesday) num = 2;
            else if (dt.DayOfWeek == DayOfWeek.Thursday) num = 3;
            else if (dt.DayOfWeek == DayOfWeek.Friday) num = 4;
            else if (dt.DayOfWeek == DayOfWeek.Saturday) num = 5;
            else if (dt.DayOfWeek == DayOfWeek.Sunday) num = 6;
            else num = -1;

            for (int i = 0; i <= num; i++)
            {
                result[i] = GetTotalOrderADate(dt.AddDays(-(num-i)));
            }

            for (int i = num + 1; i < 7; i++)
            {
                result[i] = 0;
            }
            return result;
        }

        public decimal[] GetCurrentWeekRevenue()
        {
            decimal[] result = new decimal[7];
            int num;

            DateTime dt = DateTime.Today;

            if (dt.DayOfWeek == DayOfWeek.Monday) num = 0;
            else if (dt.DayOfWeek == DayOfWeek.Tuesday) num = 1;
            else if (dt.DayOfWeek == DayOfWeek.Wednesday) num = 2;
            else if (dt.DayOfWeek == DayOfWeek.Thursday) num = 3;
            else if (dt.DayOfWeek == DayOfWeek.Friday) num = 4;
            else if (dt.DayOfWeek == DayOfWeek.Saturday) num = 5;
            else if (dt.DayOfWeek == DayOfWeek.Sunday) num = 6;
            else num = -1;

            for (int i = 0; i <= num; i++)
            {
                result[i] = GetTotalRevenueOrderADate(dt.AddDays(-(num - i)));
            }

            for (int i = num + 1; i < 7; i++)
            {
                result[i] = 0;
            }
            return result;
        }

        public Order AddOrder(Order order)
        {
            var db = new prn221_petworldContext();
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }
    }
}

