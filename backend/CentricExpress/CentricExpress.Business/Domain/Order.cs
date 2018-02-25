using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class Order : Aggregate
    {
        public Order(Guid customerId, IEnumerable<OrderLine> orderLines)
        {
            CustomerId = customerId;
        }

        public DateTime Date { get; set; }
        public Guid CustomerId { get; private set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}