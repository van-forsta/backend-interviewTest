using Confirmit.DotNetInterview.Api.Models;
using Confirmit.DotNetInterview.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            product = _productService.Add(product);
            return Created($"/products/{product.Id}", product);
        }

        [HttpGet]
        public ActionResult<List<Product>> GetList()
        {
            return Ok(_productService.GetList());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
