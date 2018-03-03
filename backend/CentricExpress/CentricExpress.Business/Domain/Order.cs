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

        private Order()
        {
            //orm
        }

        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }

        public Money TotalAmount
        {
            get
            {
                return OrderLines.Aggregate(Money.Zero, (current, orderLine) => current + orderLine.Value);
            }
        }

        public bool OrderlineValueIs(Guid itemId, Money value)
        {
            var orderLine = OrderLines.FirstOrDefault(line => line.ItemId == itemId);
            return orderLine != null && orderLine.Value.Equals(value);
        }
    }
}