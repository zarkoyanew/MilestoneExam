using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilestoneExam.Data.Models;
using MilestoneExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceFactory factory;

        public ProductController(IServiceFactory serviceFactory)
        {
            factory = serviceFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var productService = factory.GetProductService();

            return await productService.GetProducts();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var productService = factory.GetProductService();
            
            await productService.AddOrUpdateAsync(product);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var productService = factory.GetProductService();

            await productService.AddOrUpdateAsync(product);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            var productService = factory.GetProductService();

            await productService.DeleteAsync(product);

            return Ok();
        }
    }
}
