using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;
using Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Query.GetAllOrdersQuery
{
    public class OrderDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public OrderStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(vm => vm.OrderPlaced, opt => opt.MapFrom(s => s.OrderPlaced))
                .ForSourceMember(o => o.OrderDetails, opt => opt.DoNotValidate());
        }
    }
}
