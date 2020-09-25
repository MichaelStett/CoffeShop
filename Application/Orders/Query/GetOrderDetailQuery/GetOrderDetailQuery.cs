﻿using Application.Orders.Query.GetOrderDetailQuery;

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

            public GetOrderDetailQueryHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                // Disabling tracking for read-only!
                var order = _context.Orders.AsNoTracking()
                    .Include(order => order.Details)
                    .First(order => order.Id == request.Id);

                var dto = order.Details.Select(detail => _mapper.Map<OrderDetailDto>(detail))
                    .Select(detail => { detail.ProductName = _context.Products.First(p => p.Id == detail.ProductId).Name; return detail; });


                var vm = new OrderDetailVm
                {
                    OrderId = request.Id,
                    Status = order.Status,
                    Details = dto,
                    TotalPrice = order.Details.Select(d => d.Price).Sum()
                };

                return vm;
            }
        }
    }
}