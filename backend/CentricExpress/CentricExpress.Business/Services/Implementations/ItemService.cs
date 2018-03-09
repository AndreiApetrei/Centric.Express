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

        private readonly IUnitOfWork unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }

        public IList<ItemDto> Get()
        {
            return itemRepository.Get()?
                .Select(i => ItemDto.FromDomain(i))
                .ToList();
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

        public ItemDto Update(Guid id, ItemDto itemDto)
        {
            var item = itemRepository.GetById(id);

            if (item == null)
            {
                return null;
            }

            //stupid thing because EF. Semes that this will not be needed iin EF core 2.1.0
            itemRepository.PrepareForUpdate(item.Price);

            item.Description = itemDto.Description;
            item.Price = Money.From(itemDto.Price, CurrencyParser.TryParse(itemDto.Currency));

            itemRepository.UpdateItem(item);
            unitOfWork.Commit();

            return ItemDto.FromDomain(item);
        }
    }
}
