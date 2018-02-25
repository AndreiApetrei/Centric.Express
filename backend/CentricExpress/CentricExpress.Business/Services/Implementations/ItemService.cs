using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemDto> Get()
        {
            return _itemRepository.Get()?
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Description = i.Description,
                    Price = i.Price.Value 
                });
        }

        public ItemDetailsDto Get(string id)
        {
            var guid = Guid.Parse(id);

            var item = _itemRepository.GetById(guid);

            return ItemDetailsDto.MapFromModel(item);
        }

        public void GetPrices(IEnumerable<Guid> @select)
        {
        }
    }
}
