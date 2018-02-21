using System;
using System.Collections.Generic;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private readonly IItemHandler _itemHandler;

        public ItemsController(IItemHandler itemHandler)
        {
            _itemHandler = itemHandler;
        }

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return _itemHandler.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var itemDetails = _itemHandler.Get(id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return Ok(itemDetails);
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
