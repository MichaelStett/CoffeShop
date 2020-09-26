using AutoMapper;
using AutoMapper.QueryableExtensions;

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

namespace Application.Orders.Query.GetAllOrdersQuery
{
    public class GetAllOrdersQuery : IRequest<OrdersListVm>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrdersListVm>
        {
            private readonly IContext _context;
            private readonly IMapper _mapper;

            public GetAllOrdersQueryHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<OrdersListVm> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _context.Orders.AsNoTracking()
                    .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var vm = new OrdersListVm
                {
                    Orders = orders
                };

                return vm;
            }
        }
    }
}
