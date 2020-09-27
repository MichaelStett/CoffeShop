using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;
using Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Orders.Query.GetOrderDetailQuery
{
    public class OrderDetailVm
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalTimeToPrepare { get; set; }
        public int TipPercentage { get; set; }

        public OrderStatus Status { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
    }
}
