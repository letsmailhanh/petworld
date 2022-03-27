using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrderList();
        IEnumerable<Order> GetOrderListByStatus(string statusName);
        IEnumerable<Order> GetOrderListInPeriod(DateTime from, DateTime to);
        IEnumerable<Order> GetOrderListOfUser(User user);
        int GetTotalOrder(DateTime date);
        decimal GetTotalRevenue(DateTime date);
        decimal CalculateOrderRevenue(Order o);
        int[] GetCurrentWeekNumberOrder();
        decimal[] GetCurrentWeekRevenue();
        Order AddOrder(Order order);
        Order GetOrderById(int id);
    }
}
