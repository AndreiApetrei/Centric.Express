using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class Order : IAggregate
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
