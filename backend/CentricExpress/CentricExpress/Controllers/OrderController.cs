using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public void Post([FromBody] OrderDto order)
        {
            Console.WriteLine("received an order dto {0}", order);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order),
                    "order is null, check if you prpvide correct Guids for customer id and item id. If they are not valid the serialization will fail");
            }

            orderService.PlaceOrder(order);
        }
    }
}