using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetailList();
        IEnumerable<OrderDetail> GetOrderDetailListByOrder(Order o);
        IEnumerable<Product> GetProductListByOrder(Order o);
        public void AddOrderDetail(OrderDetail orderDetail);
    }
}
