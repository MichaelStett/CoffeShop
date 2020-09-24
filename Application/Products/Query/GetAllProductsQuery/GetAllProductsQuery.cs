using Domain.Entities;

using MediatR;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Query.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
        {
            public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Cappuccino S", Price = 5.99m, Quantity = 0 },
                    new Product { Id = 2, Name = "Cappuccino M", Price = 8.99m, Quantity = 0 },
                    new Product { Id = 3, Name = "Cappuccino L", Price = 9.99m, Quantity = 0 },
                    new Product { Id = 4, Name = "Espresso", Price = 4.99m, Quantity = 0 },
                    new Product { Id = 5, Name = "Espresso Doppio", Price = 5.99m, Quantity = 0 },
                    new Product { Id = 6, Name = "Americano S", Price = 4.99m, Quantity = 0 },
                    new Product { Id = 7, Name = "Americano M", Price = 6.99m, Quantity = 0 },
                    new Product { Id = 8, Name = "Americano L", Price = 8.99m, Quantity = 0 }
                };

                return products;
            }
        }
    }
}
