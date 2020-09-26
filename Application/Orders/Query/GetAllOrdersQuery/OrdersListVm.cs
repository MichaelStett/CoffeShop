using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Query.GetAllOrdersQuery
{
    public class OrdersListVm
    {
        public IList<OrderDto> Orders { get; set; }
    }
}
