﻿using Domain.Entities;
using Domain.Enums;
using Domain.Extensions;
using Domain.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore.Internal;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.Command
{
    public class SampleDataSeeder : IRequest
    {
        public class SampleDataSeederHandler : IRequestHandler<SampleDataSeeder>
        {
            private readonly IContext _context;

            public SampleDataSeederHandler(IContext context)
            {
                _context = context;
            }

            private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

            public async Task<Unit> Handle(SampleDataSeeder request, CancellationToken cancellationToken)
            {
                if (_context.Orders.Any())
                {
                    return Unit.Value;
                }

                await SeedProducts();
                await SeedOrders();

                return Unit.Value;
            }

            private async Task SeedProducts()
            {
                if (_context.Products.Any() || Products.Any())
                {
                    return;
                }

                Products.Add(1, new Product { Name = "Cappuccino S", Price = 5.99m, TimeToPrepare = 3 });
                Products.Add(2, new Product { Name = "Cappuccino M", Price = 8.99m, TimeToPrepare = 4 });
                Products.Add(3, new Product { Name = "Cappuccino L", Price = 9.99m, TimeToPrepare = 4 });
                Products.Add(4, new Product { Name = "Espresso", Price = 4.99m, TimeToPrepare = 2 });
                Products.Add(5, new Product { Name = "Espresso Doppio", Price = 5.99m, TimeToPrepare = 4 });
                Products.Add(6, new Product { Name = "Americano S", Price = 4.99m, TimeToPrepare = 2 });
                Products.Add(7, new Product { Name = "Americano M", Price = 6.99m, TimeToPrepare = 3 });
                Products.Add(8, new Product { Name = "Americano L", Price = 8.99m, TimeToPrepare = 4 });
                Products.Add(9, new Product { Name = "Latte S", Price = 6.99m, TimeToPrepare = 4 });
                Products.Add(10, new Product { Name = "Latte M", Price = 8.59m, TimeToPrepare = 4 });
                Products.Add(11, new Product { Name = "Latte L", Price = 9.99m, TimeToPrepare = 5 });

                foreach (var product in Products.Values)
                {
                    _context.Products.Add(product);
                }

                await _context.SaveChangesAsync();
            }

            private async Task SeedOrders()
            {
                var orders = new List<Order>()
                {
                    new Order
                    {
                        OrderPlaced = DateTime.UtcNow,
                        OrderCompleted = DateTime.UtcNow.AddMinutes(7),
                        Status = OrderStatus.Completed
                    }.AddOrderDetails(
                        new OrderDetail { Product = Products[1], Quantity = 2, },
                        new OrderDetail { Product = Products[2], Quantity = 1, }),

                    new Order
                    {
                        OrderPlaced = DateTime.UtcNow,
                        OrderCompleted = DateTime.UtcNow.AddMinutes(2),
                        Status = OrderStatus.Completed
                    }.AddOrderDetails(
                        new OrderDetail { Product = Products[3], Quantity = 1, }),

                    new Order
                    {
                        OrderPlaced = DateTime.UtcNow,
                        OrderCompleted = DateTime.UtcNow.AddMinutes(9),
                        Status = OrderStatus.Completed,
                    }.AddOrderDetails(
                        new OrderDetail { Product = Products[4], Quantity = 1, },
                        new OrderDetail { Product = Products[5], Quantity = 3, }),

                    new Order
                    {
                        OrderPlaced = DateTime.UtcNow,
                        OrderCompleted = DateTime.UtcNow.AddMinutes(6),
                        Status = OrderStatus.Completed,
                    }.AddOrderDetails(
                        new OrderDetail { Product = Products[6], Quantity = 2, }),

                    new Order
                    {
                        OrderPlaced = DateTime.UtcNow,
                        OrderCompleted = DateTime.UtcNow.AddMinutes(5),
                        Status = OrderStatus.Completed,
                    }.AddOrderDetails(
                        new OrderDetail { Product = Products[7], Quantity = 3, }),
                };

                foreach (var order in orders)
                {
                    foreach (var detail in order.OrderDetails)
                    {
                        detail.UnitPrice = detail.Product.Price * detail.Quantity;
                        detail.UnitTimeToPrepare = detail.Product.TimeToPrepare * detail.Quantity;
                    }
                }

                _context.Orders.AddRange(orders);

                await _context.SaveChangesAsync();
            }
        }
    }

    
}
