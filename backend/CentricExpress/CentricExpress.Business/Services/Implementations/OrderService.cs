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

            Console.WriteLine("order line numbers = {0}", order.OrderLines.Count);
            
            orderRepository.Insert(order);
            orderRepository.SaveChanges();
                 }

        private IDictionary<Guid, Money> GetItemPrices(OrderDto orderDto)
        {
            return itemRepository.GetPrices(orderDto.OrderLines.Select(dto => dto.ItemId));
        }
    }
}