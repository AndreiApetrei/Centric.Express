using System;
using CentricExpress.Business.Repositories;
using CentricExpress.Business.Services.Implementations;

namespace CentricExpress.DataAccess.Repositories
{
    public class CustomerOrdersRepository : ICustomerOrdersRepository
    {
        private readonly IOrderRepository orderRepository;

        public CustomerOrdersRepository(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public CustomerOrders GetByCustomerId(Guid customerId)
        {
            return new CustomerOrders(customerId);
        }

        public void Save(CustomerOrders customerOrders)
        {
            orderRepository.Insert(customerOrders.NewOrder);
        }
    }
}