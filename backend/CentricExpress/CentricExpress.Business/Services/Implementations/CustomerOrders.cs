using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Services.Implementations
{
    public class CustomerOrders
    {
        private readonly Guid customerId;

        public CustomerOrders(Guid customerId)
        {
            this.customerId = customerId;
        }
        
        public CustomerOrders()
        {
        }

        public Order NewOrder { get; private set; }

        public void PlaceOrder(Order order)
        {
            NewOrder = order;
        }
    }
}