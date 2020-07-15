using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Models;

namespace ShoppingCore.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET api/values
        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await this.productService.GetAll());
        }
        [Route("gethotproduct")]
        [HttpGet]
        public async Task<IActionResult> gethotproduct(int top)
        {
            return new OkObjectResult(await this.productService.gethotproduct(top));
        }

        [Route("lastest")]
        [HttpGet]
        public async Task<IActionResult> gelastproduct(int top)
        {
            return new OkObjectResult(await this.productService.getlastproduct(top));
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]

        public async Task<IActionResult> GetByIdt(int id)
        {
            return new OkObjectResult(await this.productService.GetById(id));
        }

    }
}
