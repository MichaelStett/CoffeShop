using Application.Orders.Query.GetOrderDetailQuery;

using AutoMapper;

using Domain.Entities;
using Domain.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Query.GetOrderQuery
{
    public class GetOrderDetailQuery : IRequest<OrderDetailVm>
    {
        public int Id { get; set; }

        public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
        {
            public readonly IContext _context;
            public readonly IMapper _mapper;

            private const int TIP_PERCENTAGE = 10;
            private const int TIP_THRESHOLD = 5;

            public GetOrderDetailQueryHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var order = _context.Orders.AsNoTracking()
                    .Include(order => order.OrderDetails)
                    .First(order => order.Id == request.Id);

                // TODO: Use Mapper?
                var dto = order.OrderDetails
                    .Select(d => new OrderDetailDto 
                    { 
                        ProductName = _context.Products.First(p => p.Id == d.ProductId).Name,
                        UnitPrice = d.UnitPrice,
                        UnitTimeToPrepare = d.UnitTimeToPrepare,
                        Quantity = d.Quantity
                    });

                var vm = new OrderDetailVm
                {
                    OrderId = request.Id,
                    Status = order.Status,
                    Details = dto,
                    TotalPrice = order.OrderDetails.Select(d => d.UnitPrice).Sum(),
                    TotalTimeToPrepare = order.OrderDetails.Select(d => d.UnitTimeToPrepare).Sum(),
                    TipPercentage = 0,
                };

                var quantity = dto.Select(o => o.Quantity).Sum();

                if (quantity > TIP_THRESHOLD)
                {
                    vm.TipPercentage = TIP_PERCENTAGE;
                    vm.TotalPrice = vm.TotalPrice * (1 + (vm.TipPercentage / 100m));
                }

                return vm;
            }
        }
    }
}
