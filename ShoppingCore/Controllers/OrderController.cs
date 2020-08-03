using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Applicatons.Dtos.Orders;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using System.Threading.Tasks;

namespace ShoppingCore.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class OrderController : ApiBaseController
    {

        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET api/values

        [Route("createcart")]
        [HttpPost]

        public async Task<IActionResult> CreateOrder([FromBody]CreateCartModel model)
        {
            return new OkObjectResult(await this.orderService.CreateOrder(model.orderViewModel, model.listcart));
        }


    }

   
}
