using Application.Orders.Command.CreateOrderCommand;
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

            CreateMap<OrderDetailOtd, OrderDetail>()
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity));
                
        }
    }
}
