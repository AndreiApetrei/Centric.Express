using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            return Ok(this.customerService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest(ModelState);
            }

            var customer = this.customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
