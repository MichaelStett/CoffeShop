using Application.Common.Mappings;

using AutoMapper;

using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Query.GetAllProductsQuery
{
    public class ProductDto : IMapFrom<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TimeToPrepare { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(vm => vm.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(vm => vm.TimeToPrepare, opt => opt.MapFrom(s => s.TimeToPrepare))
                .ForMember(vm => vm.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}
