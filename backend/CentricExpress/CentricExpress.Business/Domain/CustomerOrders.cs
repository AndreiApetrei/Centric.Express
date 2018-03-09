using System;

namespace CentricExpress.Business.Domain
{
    public class CustomerOrders
    {
        public CustomerOrders(Guid customerId, int existingPoints = 0, string customerName = "")
        {
            CustomerId = customerId;
            ExistingPoints = existingPoints;
            CustomerName = customerName;
        }

        public CustomerOrders()
        {
        }

        private int ExistingPoints { get; }
        private Guid CustomerId { get; }

        public string CustomerName { get; }
        public Order NewOrder { get; private set; }
        public CustomerPoints NewPoints { get; private set; }

        public int TotalPoints => ExistingPoints + NewPoints?.Points ?? 0;
        public Money NewOrderDiscount => NewOrder == null ? Money.Zero : NewOrder.Discount;

        public void PlaceOrder(Order order, IPointsCalculator pointsCalculator, IDiscountCalculator discountCalculator = null) 
        {
            NewOrder = order;

            if (order == null)
            {
                return;
            }

            order.SetCustomerId(CustomerId);
            
            order.ApplyDiscount(discountCalculator, ExistingPoints);
            NewPoints = order.GetPoints(pointsCalculator);
        }
    }
}