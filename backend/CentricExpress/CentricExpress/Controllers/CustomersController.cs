using System;
using CentricExpress.Business.DTOs;
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

        [HttpPost]
        public IActionResult Post([FromBody]CustomerDto customer)
        {
            if (customer == null || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var customerId = customerService.Add(customer);

            var customerDto = customerService.Get(customerId);
            return CreatedAtAction("Get", new { id = customerId }, customerDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null || customerService.Get(id) == null)
            {
                return NotFound();
            }

            customerService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]CustomerDto customer)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var updatedItem = customerService.Update(id, customer);

            if (updatedItem == null)
            {
                return NotFound(id);
            }

            return NoContent();
        }
    }
}