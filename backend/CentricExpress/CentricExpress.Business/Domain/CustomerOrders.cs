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

        public void PlaceOrder(Order order, IPointsCalculator pointsCalculator)
        {
            NewOrder = order;
            if (order != null)
            {
                NewPoints = order.GetPoints(pointsCalculator);
            }
        }
    }
}