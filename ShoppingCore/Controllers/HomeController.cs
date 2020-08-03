using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController:ApiBaseController
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await this.homeService.GetAllHomeData());
        }

    }
}
