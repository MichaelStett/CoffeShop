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
    public class OrderDetailVm : IMapFrom<Order>
    {
        public int OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderDetailDto> Details { get; set; }

        public decimal TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailVm>()
                .ForMember(vm => vm.OrderId, opt => opt.MapFrom(s => s.Id))
                .ForMember(vm => vm.Details, opt => opt.MapFrom(s => s.Details))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(s => s.Status));
        }
    }
}
