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
    public class CustomerController : ControllerBase
    {
        private readonly IServiceFactory factory;

        public CustomerController(IServiceFactory serviceFactory)
        {
            factory = serviceFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customerService = factory.GetCustomerService();

            return await customerService.GetCustomers();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var customerService = factory.GetCustomerService();

            await customerService.AddOrUpdateAsync(customer);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            var customerService = factory.GetCustomerService();

            await customerService.AddOrUpdateAsync(customer);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromBody] Customer customer)
        {
            var customerService = factory.GetCustomerService();

            await customerService.DeleteAsync(customer);

            return Ok();
        }

    }
}
