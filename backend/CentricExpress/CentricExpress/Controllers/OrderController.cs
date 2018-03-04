using System;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order),
                    "order is null, check if you provide correct Guids for customer id and item id. If they are not valid the serialization will fail");
            }

            var orderPayment = orderService.PlaceOrder(order);

            if (orderPayment.Status == Status.NoCustomerFound)
            {
                return NotFound(order.CustomerId);
            }

            return CreatedAtAction("Get", new { id = orderPayment.OrderId }, orderPayment);
        }
    }
}