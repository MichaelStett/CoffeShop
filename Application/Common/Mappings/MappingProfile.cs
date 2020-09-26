using Application.Orders.Command.CreateOrderCommand;
using Application.Orders.Query.GetAllOrdersQuery;
using Application.Orders.Query.GetOrderDetailQuery;
using Application.Products.Query.GetAllProductsQuery;

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
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailOtd, OrderDetail>();

            CreateMap<Product, ProductDto>();
        }
    }
}
