using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;

        private readonly IUnitOfWork unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
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

        public ItemDto Get(Guid id)
        {
            var item = itemRepository.GetById(id);

            return ItemDto.FromDomain(item);
        }

        public Guid Add(ItemDto itemDto)
        {
            itemDto.Id = Guid.NewGuid();

            itemRepository.Insert(itemDto.ToDomain());
            unitOfWork.Commit();

            return itemDto.Id;
        }

        public void Delete(Guid id)
        {
            itemRepository.Remove(id);
            unitOfWork.Commit();
        }

        public ItemDto Update(ItemDto item)
        {
            itemRepository.Update(item.ToDomain());
            unitOfWork.Commit();
            return item;
        }
    }
}
