using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Products.Query.GetAllProductsQuery;

using Domain.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetAllProductsQuery());

            return base.Ok(vm);
        }
    }
}
