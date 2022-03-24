using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
