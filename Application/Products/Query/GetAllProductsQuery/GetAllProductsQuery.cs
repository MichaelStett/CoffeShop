using AutoMapper;
using AutoMapper.QueryableExtensions;

using Domain.Entities;
using Domain.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Query.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<ProductsListVm>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsListVm>
        {
            private readonly IContext _context;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<ProductsListVm> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.AsNoTracking()
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var vm = new ProductsListVm
                {
                    Products = products
                };

                return vm;
            }
        }
    }
}
