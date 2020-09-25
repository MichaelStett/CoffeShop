using Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public OrderStatus Status { get; set; }
    }
}
