using Domain.Entities;
using Domain.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Query.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
        {
            private readonly IContext _context;

            public GetAllProductsQueryHandler(IContext context)
                => (_context) = (context);

            public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();

                return products;
            }
        }
    }
}
