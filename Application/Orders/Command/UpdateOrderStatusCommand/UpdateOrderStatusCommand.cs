using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

using MediatR;

using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Command.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public int OrderId { get; set; }
        
        public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
        {
            public readonly IContext _context;

            public UpdateOrderStatusCommandHandler(IContext context)
                => (_context) = (context);

            public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
            {
                var order = _context.Orders.Find(request.OrderId);

                if (order == null)
                {
                    return Unit.Value;
                }

                if (order.Status != OrderStatus.Completed)
                {
                    order.Status += 1;


                    if (order.Status == OrderStatus.Completed)
                    {
                        order.OrderCompleted = DateTime.UtcNow;
                    }

                    _context.Orders.Update(order);
                }

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
