using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Orders.Command.CreateOrderCommand;
using Application.Orders.Command.UpdateOrderStatusCommand;
using Application.Orders.Query.GetAllOrdersQuery;
using Application.Orders.Query.GetOrderDetailQuery;
using Application.Orders.Query.GetOrderQuery;

using Domain.Entities;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class OrdersController : BaseController
    {
        [HttpGet]
        public async Task<OrdersListVm> GetAll()
        {
            return await Mediator.Send(new GetAllOrdersQuery());
        }

        [HttpGet("{id}")]
        public async Task<OrderDetailVm> GetById(int id)
        {
            return await Mediator.Send(new GetOrderDetailQuery() { Id = id });
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update Order Status by one step
        /// </summary>
        [HttpPut("{id}")]
        public async Task<Unit> UpdateStatus(int id)
        {
            return await Mediator.Send(new UpdateOrderStatusCommand() { OrderId = id });
        }
    }
}
