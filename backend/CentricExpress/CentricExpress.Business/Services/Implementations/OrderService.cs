using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    internal class OrderService : IOrderService
    {
        private readonly IItemRepository itemRepository;
        private readonly IRepository<Order> orderRepository;

        public OrderService(IRepository<Order> orderRepository, IItemRepository itemRepository)
        {
            this.orderRepository = orderRepository;
            this.itemRepository = itemRepository;
        }

        public void PlaceOrder(OrderDto orderDto)
        {
            Order order = orderDto.ToDomain(GetItemPrices(orderDto));
            orderRepository.Insert(order);
        }

        private IDictionary<Guid, Money> GetItemPrices(OrderDto orderDto)
        {
            return itemRepository.GetPrices(orderDto.OrderLines.Select(dto => dto.ItemId));
        }
    }
}