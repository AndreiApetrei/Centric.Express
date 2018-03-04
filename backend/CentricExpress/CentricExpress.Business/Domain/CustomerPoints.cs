using System;

namespace CentricExpress.Business.Domain
{
    public class CustomerPoints
    {
        public int Points { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public CustomerPoints(int points, Guid customerId, Guid orderId)
        {
            Points = points;
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}