using System;
using System.Collections.Generic;
using System.Linq;

using CentricExpress.Business.DTOs;
using CentricExpress.Business.Mappers.DomainToDto;
using CentricExpress.Business.Mappers.DtoToDomain;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository repository;

        public ItemService(IItemRepository repository)
        {
            this.repository = repository;
        }

        public IList<ItemDto> Get()
        {
            return repository.Get()?.Select(i => i.MapToItemDto()).ToList();
        }

        public ItemDto Get(Guid id)
        {
            return repository.GetById(id).MapToItemDto();
        }

        public Guid Add(ItemDto itemDto)
        {
            itemDto.Id = Guid.NewGuid();
            repository.Insert(itemDto.MapToItem());
            repository.SaveChanges();

            return itemDto.Id;
        }

        public ItemDto Update(Guid id, ItemDto itemDto)
        {
            var item = repository.GetById(id);

            if (item == null || itemDto.Id != id)
            {
                return null;
            }
            
            repository.Update(itemDto.MapToItem(item));
            repository.SaveChanges();

            return itemDto;
        }

        public void Delete(Guid id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }
    }
}
