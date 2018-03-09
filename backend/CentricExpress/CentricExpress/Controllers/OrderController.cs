using System;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Route("api/customer")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        
        [HttpGet("{customerId}/order/{id}")]
        public IActionResult Get(Guid customerId, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = orderService.GetById(id, customerId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [Route("{customerId}/order")]
        [HttpPost]
        public IActionResult Post(Guid customerId, [FromBody] OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (order == null)
            {
                return BadRequest();
            }

            var orderPayment = orderService.PlaceOrder(order, customerId);

            if (orderPayment.Status == Status.NoCustomerFound)
            {
                return NotFound(customerId);
            }

            return CreatedAtAction("Get", new { customerId = customerId, id = orderPayment.OrderId }, orderPayment);
        }
    }
}