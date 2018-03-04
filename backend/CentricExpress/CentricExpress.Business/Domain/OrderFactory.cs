using System;
using System.Linq;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Domain
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
            return orderDto.ToDomain(itemRepository.GetPrices(GetItemIds(orderDto)));
        }

        private static Guid[] GetItemIds(OrderDto orderDto)
        {
            return orderDto.OrderLines?.Select(dto => dto.ItemId).ToArray();
        }
    }
}