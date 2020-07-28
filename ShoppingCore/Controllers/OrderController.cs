using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Applicatons.Intfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET api/values

        [Route("createcart")]
        [HttpGet]

        public async Task<IActionResult> CreateOrder(string orderViewModel, string listcart)
        {
            return new OkObjectResult(await this.orderService.CreateOrder(orderViewModel, listcart));
        }


    }
}
