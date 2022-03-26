using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);

        public IEnumerable<OrderDetail> GetOrderDetailList() => OrderDetailDAO.Instance.GetOrderDetailList();

        public IEnumerable<OrderDetail> GetOrderDetailListByOrder(Order o) => OrderDetailDAO.Instance.GetOrderDetailByOrder(o);

        public IEnumerable<Product> GetProductListByOrder(Order o) => OrderDetailDAO.Instance.GetProductListByOrder(o);
    }
}
