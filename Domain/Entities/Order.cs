using Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderCompleted { get; set; }
        public OrderStatus Status { get; set; }
    }
}
