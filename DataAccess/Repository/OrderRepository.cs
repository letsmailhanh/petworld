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
        public IEnumerable<Order> GetOrderList() => OrderDAO.Instance.GetOrderList();
    }
}
