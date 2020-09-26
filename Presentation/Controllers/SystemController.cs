using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.System.Command;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class SystemController : BaseController
    {
        [HttpGet]
        public async Task<Unit> SeedDatabase()
        {
            return await Mediator.Send(new SampleDataSeeder()); 
        }
    }
}
