using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Handlers.Implementations
{
    public class ItemHandler : IItemHandler
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemDetailsDto> Get()
        {
            return _itemRepository.Get()?
                .Select(i => new ItemDetailsDto
                {
                    Id = i.Id,
                    Description = i.Description,
                    Price = i.Price
                });
        }
    }
}
