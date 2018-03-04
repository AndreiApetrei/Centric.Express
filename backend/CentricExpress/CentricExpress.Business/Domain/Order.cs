using System;
using System.Collections.Generic;
using System.Linq;

namespace CentricExpress.Business.Domain
{
    public class Order : Aggregate
    {
        public Order(Guid customerId, IEnumerable<OrderLine> orderLines) : this(customerId)
        {
            OrderLines = orderLines.ToList();
        }

        private Order()
        {
            //orm
        }

        public Order(Guid customerId)
        {
            CustomerId = customerId;
            Date = DateTime.Now;
        }

        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }

        public Money TotalAmount
        {
            get { return OrderLines.Aggregate(Money.Zero, (current, orderLine) => current + orderLine.Value); }
        }

        public bool OrderlineValueIs(Guid itemId, Money value)
        {
            var orderLine = OrderLines.FirstOrDefault(line => line.ItemId == itemId);
            return orderLine != null && orderLine.Value.Equals(value);
        }

        public Order AddOrderLine(Guid itemId, int quantity, Money price)
        {
            if (OrderLines == null)
            {
                OrderLines = new List<OrderLine>();
            }

            OrderLines.Add(new OrderLine(itemId, quantity, price));
            return this;
        }

        public CustomerPoints GetPoints(IPointsCalculator pointsCalculator)
        {
            return new CustomerPoints(pointsCalculator?.Calculate(this) ?? 0, CustomerId, Id);
        }
    }
}