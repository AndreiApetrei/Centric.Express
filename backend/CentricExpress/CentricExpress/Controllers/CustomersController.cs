using System;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}