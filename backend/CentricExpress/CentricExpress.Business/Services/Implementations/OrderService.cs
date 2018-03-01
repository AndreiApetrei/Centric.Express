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

        public void PlaceOrder(OrderDto orderDto)
        {
            var order = orderFactory.CreateOrder(orderDto);
            
            orderRepository.Insert(order);
            orderRepository.SaveChanges();
        }
    }

    public interface IOrderFactory
    {
        Order CreateOrder(OrderDto orderDto);
    }
}