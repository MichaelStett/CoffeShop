using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;
using Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Query.GetAllOrdersQuery
{
    public class OrdersVm : IMapFrom<Order>
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrdersVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(s => s.Status))
                .ForSourceMember(o => o.Details, opt => opt.DoNotValidate());
        }
    }
}
