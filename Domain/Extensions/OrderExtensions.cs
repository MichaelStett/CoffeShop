using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class OrderExtensions
    {
        public static Order AddOrderDetails(this Order order, params OrderDetail[] orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                order.OrderDetails.Add(orderDetail);
            }

            return order;
        }

        public static Order AddOrderDetails(this Order order, List<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                order.OrderDetails.Add(orderDetail);
            }

            return order;
        }
    }
}
