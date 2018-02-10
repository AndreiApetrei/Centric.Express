using System;

namespace CentricExpress.Business.Domain
{
    public class OrderLine : IAggregate
    {
        public Guid Id { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
