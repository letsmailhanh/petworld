using DataAccess.DAO;
using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public decimal CalculateOrderRevenue(Order o) => OrderDAO.Instance.CalculateOrderRevenue(o);

        public int[] GetCurrentWeekNumberOrder() => OrderDAO.Instance.GetCurrentWeekNumberOrder();

        public decimal[] GetCurrentWeekRevenue() => OrderDAO.Instance.GetCurrentWeekRevenue();

        public Order GetOrderById(int id) => OrderDAO.Instance.GetOrderById(id);

        public IEnumerable<Order> GetOrderList() => OrderDAO.Instance.GetOrderList();

        public IEnumerable<Order> GetOrderListByStatus(string statusName) => OrderDAO.Instance.GetOrderListByStatus(statusName);

        public IEnumerable<Order> GetOrderListInPeriod(DateTime from, DateTime to) => OrderDAO.Instance.GetOrderListInPeriod(from, to);

        public IEnumerable<Order> GetOrderListOfUser(User user) => OrderDAO.Instance.GetOrderListOfUser(user);

        public int GetTotalOrder(DateTime date) => OrderDAO.Instance.GetTotalOrderADate(date);

        public decimal GetTotalRevenue(DateTime date) => OrderDAO.Instance.GetTotalRevenueOrderADate(date);
    }
}
