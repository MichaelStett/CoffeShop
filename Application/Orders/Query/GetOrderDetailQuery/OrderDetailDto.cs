using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Orders.Query.GetOrderDetailQuery
{
    public class OrderDetailDto : IMapFrom<OrderDetail>
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(vm => vm.ProductName, opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(vm => vm.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(vm => vm.UnitPrice, opt => opt.MapFrom(s => s.UnitPrice));
        }
    }
}
