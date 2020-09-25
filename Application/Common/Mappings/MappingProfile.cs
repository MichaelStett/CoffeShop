using Application.Orders.Query.GetAllOrdersQuery;
using Application.Orders.Query.GetOrderDetailQuery;

using AutoMapper;

using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>();
            CreateMap<OrderDetail, OrderDetailDto>();
        }
    }
}
