using System;
using System.Collections.Generic;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = itemService.Get();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == null || ModelState.IsValid == false)
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
        public IActionResult Post([FromBody]ItemDto item)
        {
            if (item == null || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var itemId = itemService.Insert(item);

            var itemDto = itemService.Get(itemId);
            return CreatedAtAction("Get", new { id = itemId }, itemDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null || itemService.Get(id) == null)
            {
                return NotFound();
            }

            itemService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
