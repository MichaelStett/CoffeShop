using Domain.Entities;
using Domain.Enums;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Seed
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var context = serviceScope.ServiceProvider.GetService<Context>();

            context.Database.EnsureCreated();

            #region Products
            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Name = "Cappuccino S",
                        Price = 5.99m
                    },
                    new Product
                    {
                        Name = "Cappuccino M",
                        Price = 8.99m
                    },
                    new Product
                    {
                        Name = "Cappuccino L",
                        Price = 9.99m
                    },
                    new Product
                    {
                        Name = "Espresso",
                        Price = 4.99m
                    },
                    new Product
                    {
                        Name = "Espresso Doppio",
                        Price = 5.99m
                    },
                    new Product
                    {
                        Name = "Americano S",
                        Price = 4.99m
                    },
                    new Product
                    {
                        Name = "Americano M",
                        Price = 6.99m
                    },
                    new Product
                    {
                        Name = "Americano L",
                        Price = 8.99m
                    },
                    new Product
                    {
                        Name = "Latte M",
                        Price = 7.99m
                    },
                    new Product
                    {
                        Name = "Latte L",
                        Price = 9.99m
                    }
                };

                context.Products.AddRange(products);
            }

            context.SaveChanges();
            #endregion

            #region Orders
            if (!context.Orders.Any())
            {
                var orders = new List<Order>()
                {
                    new Order
                    {
                        Status = OrderStatus.Completed,
                        Details = new List<OrderDetail>
                        {
                            new OrderDetail
                            {
                                ProductId = 1,
                                Quantity = 2,
                            },
                            new OrderDetail
                            {
                                ProductId = 4,
                                Quantity = 1,
                            },
                        }
                    },
                    new Order
                    {
                        Status = OrderStatus.Completed,
                        Details = new List<OrderDetail>
                        {
                            new OrderDetail
                            {
                                ProductId = 5,
                                Quantity = 1,
                            },
                        }
                    },
                    new Order
                    {
                        Status = OrderStatus.Completed,
                        Details = new List<OrderDetail>
                        {
                            new OrderDetail
                            {
                                ProductId = 1,
                                Quantity = 2,
                            },
                        }
                    },
                    new Order
                    {
                        Status = OrderStatus.Completed,
                        Details = new List<OrderDetail>
                        {
                            new OrderDetail
                            {
                                ProductId = 7,
                                Quantity = 3,
                            },
                        }
                    },
                };

                foreach (var order in orders)
                {
                    foreach (var detail in order.Details)
                    {
                        var price = context.Products.First(p => p.Id == detail.ProductId).Price;

                        detail.OrderPlaced = DateTime.UtcNow;
                        detail.Price = price * detail.Quantity;
                    }
                }

                context.Orders.AddRange(orders);
            }

            context.SaveChanges();
            #endregion
        }
    }
}
