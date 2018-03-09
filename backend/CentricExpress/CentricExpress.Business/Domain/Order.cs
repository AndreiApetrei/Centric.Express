using System;
using System.Collections.Generic;
using System.Linq;

namespace CentricExpress.Business.Domain
{
    public class Order : Aggregate
    {
        public Order(IEnumerable<OrderLine> orderLines)
        {
            OrderLines = orderLines.ToList();
            Date = DateTime.Now;
        }

        public Order()
        {
            //orm
        }

        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }

        public Money TotalAmount
        {
            get { return OrderLines.Aggregate(Money.Zero, (current, orderLine) => current + orderLine.Value); }
        }

        public Money Discount { get; private set; }

        public Money PayAmount => TotalAmount - Discount;

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

        public void ApplyDiscount(IDiscountCalculator discountCalculator, int existingPoints)
        {
            if (discountCalculator == null)
            {
                return;
            }
            
            Discount = discountCalculator.GetDiscount(this, existingPoints);
        }

        public void SetCustomerId(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}