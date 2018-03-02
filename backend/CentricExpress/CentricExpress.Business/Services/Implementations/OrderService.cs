using System;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IOrderFactory orderFactory;

        public OrderService(IRepository<Order> orderRepository, IOrderFactory orderFactory)
        {
            this.orderRepository = orderRepository;
            this.orderFactory = orderFactory;
        }

        public Guid PlaceOrder(OrderDto orderDto)
        {
            var order = orderFactory.CreateOrder(orderDto);
            
            orderRepository.Insert(order);
            orderRepository.SaveChanges();

            return order?.Id ?? Guid.Empty;
        }

        public OrderDto GetById(Guid id)
        {
            return OrderDto.FromDomain(orderRepository.GetById(id));
        }
    }
}