using System;
using System.Collections.Generic;
using System.Linq;

namespace CentricExpress.Business.Domain
{
    public class Order : Aggregate
    {
        public Order(Guid customerId, IEnumerable<OrderLine> orderLines)
        {
            CustomerId = customerId;
            OrderLines = orderLines.ToList();
            Date = DateTime.Now;    
        }

        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }
    }
}