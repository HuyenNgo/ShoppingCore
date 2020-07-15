using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Models;

namespace ShoppingCore.Controllers
{

    [Route("api/productcategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {

        private readonly IProductCategoryService productCategoryService;
        public ProductCategoryController (IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        // GET api/values

        [Route("clientgetallparents")]
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await this.productCategoryService.ClientGetAll());
        }


    }
}
