using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class OrderService : IOrderService
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
            var order = orderDto.ToDomain(itemRepository.GetPrices);
            
            orderRepository.Insert(order);
            orderRepository.SaveChanges();
        }
    }
}