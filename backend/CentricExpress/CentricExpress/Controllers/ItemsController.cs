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

        // GET: api/Item
        [HttpGet]
        public IEnumerable<ItemDetailsDto> Get()
        {
            return _itemHandler.Get();
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Item
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
