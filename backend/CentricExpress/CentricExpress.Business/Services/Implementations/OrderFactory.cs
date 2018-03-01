using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IItemRepository itemRepository;

        public OrderFactory(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public Order CreateOrder(OrderDto orderDto)
        {
            return orderDto.ToDomain(itemIds => itemRepository.GetPrices(itemIds));
        }
    }
}