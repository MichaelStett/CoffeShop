using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Orders.Query.GetAllOrdersQuery;
using Application.Orders.Query.GetOrderDetailQuery;
using Application.Orders.Query.GetOrderQuery;

using Domain.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class OrdersController : BaseController
    {
        [HttpGet]
        public async Task<IEnumerable<OrdersVm>> GetAll()
        {
            return await Mediator.Send(new GetAllOrdersQuery());
        }

        [HttpGet("{id}")]
        public async Task<OrderDetailVm> GetById(int id)
        {
            return await Mediator.Send(new GetOrderDetailQuery() { Id = id });
        }
    }
}
