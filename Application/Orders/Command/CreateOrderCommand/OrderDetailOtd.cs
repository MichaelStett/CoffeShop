using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Command.CreateOrderCommand
{
    public class OrderDetailOtd
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
