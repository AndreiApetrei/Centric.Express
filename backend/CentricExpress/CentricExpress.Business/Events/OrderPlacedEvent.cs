using System;

namespace CentricExpress.Business.Events
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; }

        public OrderPlacedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}