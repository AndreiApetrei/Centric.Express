using System;
using System.Collections.Generic;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return itemService.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetails = itemService.Get(id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return Ok(itemDetails);
        }
        
        [HttpPost]
        public void Post([FromBody]ItemDto item)
        {
            // item to be added in database
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
