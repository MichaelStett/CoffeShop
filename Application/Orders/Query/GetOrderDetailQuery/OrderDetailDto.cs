using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;
using Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Orders.Query.GetOrderDetailQuery
{
    public class OrderDetailDto : IMapFrom<OrderDetail>
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderPlaced { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(vm => vm.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(vm => vm.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(vm => vm.OrderPlaced, opt => opt.MapFrom(s => ((DateTime)s.OrderPlaced).ToShortTimeString()))
                .ForMember(vm => vm.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}
