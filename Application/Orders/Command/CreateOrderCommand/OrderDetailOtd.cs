using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Command.CreateOrderCommand
{
    public class OrderDetailOtd
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
