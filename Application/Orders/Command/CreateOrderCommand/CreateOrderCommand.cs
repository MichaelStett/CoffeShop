using AutoMapper;

using Domain.Entities;
using Domain.Enums;
using Domain.Extensions;
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
    public class CreateOrderCommand : IRequest
    {
        public IEnumerable<OrderDetailOtd> Details { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
        {
            public readonly IContext _context;
            public readonly IMapper _mapper;

            public CreateOrderCommandHandler(IContext context, IMapper mapper)
                => (_context, _mapper) = (context, mapper);

            public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var details = request.Details.Select(o => new OrderDetail
                {
                    Quantity = o.Quantity,
                    Product = _context.Products.First(p => p.Id == o.ProductId),
                    AdditionalInfo = o.AdditionalInfo
                }).ToList();

                foreach (var detail in details)
                {
                    detail.UnitPrice = detail.Product.Price * detail.Quantity;
                    detail.UnitTimeToPrepare = detail.Product.TimeToPrepare * detail.Quantity;
                }

                var order = new Order
                {
                    Status = OrderStatus.NotStarted,
                    OrderPlaced = DateTime.UtcNow,
                    OrderCompleted = null,
                }.AddOrderDetails(details);
                
                _context.Orders.Add(order);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
