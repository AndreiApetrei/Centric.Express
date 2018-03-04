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
        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public IList<ItemDto> Get()
        {
            return itemRepository.Get()?
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Description = i.Description,
                    Price = i.Price.Value 
                }).ToList();
        }

        public ItemDetailsDto Get(Guid id)
        {
            var item = itemRepository.GetById(id);

            return ItemDetailsDto.MapFromModel(item);
        }

        public Guid Insert(ItemDto itemDto)
        {
            itemDto.Id = Guid.NewGuid();

            itemRepository.Insert(itemDto.ToDomain());
            itemRepository.SaveChanges();

            return itemDto.Id;
        }
    }
}
