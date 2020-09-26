using AutoMapper;

using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Command.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public IEnumerable<OrderDetailOtd> Details { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
        {
            public readonly IContext _context;
            public readonly IMapper _mapper;

            public CreateOrderCommandHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var details = request.Details.Select(d => _mapper.Map<OrderDetail>(d)).ToList();

                
                var order = new Order
                {
                    Status = OrderStatus.NotStarted,
                    OrderDetails = details
                };

                _context.Orders.Add(order);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
