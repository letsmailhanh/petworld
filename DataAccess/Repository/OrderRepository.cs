using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderRepository : IOrderRepository
    {
        public int[] GetCurrentWeekNumberOrder() => OrderDAO.Instance.GetCurrentWeekNumberOrder();

        public decimal[] GetCurrentWeekRevenue() => OrderDAO.Instance.GetCurrentWeekRevenue();

        public IEnumerable<Order> GetOrderList() => OrderDAO.Instance.GetOrderList();

        public IEnumerable<Order> GetOrderListByStatus(string statusName) => OrderDAO.Instance.GetOrderListByStatus(statusName);

        public IEnumerable<Order> GetOrderListInPeriod(DateTime from, DateTime to) => OrderDAO.Instance.GetOrderListInPeriod(from, to);

        public int GetTotalOrder(DateTime date) => OrderDAO.Instance.GetTotalOrderADate(date);

        public decimal GetTotalRevenue(DateTime date) => OrderDAO.Instance.GetTotalRevenueOrderADate(date);
    }
}
