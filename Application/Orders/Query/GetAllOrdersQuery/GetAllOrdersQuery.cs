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
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrdersVm>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrdersVm>>
        {
            private readonly IContext _context;
            private readonly IMapper _mapper;

            public GetAllOrdersQueryHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<IEnumerable<OrdersVm>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = _context.Orders.AsNoTracking();

                var vm = orders.Select(order => _mapper.Map<OrdersVm>(order)).ToList();

                return vm;
            }
        }
    }
}
