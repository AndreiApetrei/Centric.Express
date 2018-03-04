using System;

namespace CentricExpress.Business.Domain
{
    public class CustomerOrders
    {
        private readonly Guid customerId;
        public string CustomerName { get; }

        public CustomerOrders(Guid customerId, int existingPoints = 0, string customerName = "")
        {
            ExistingPoints = existingPoints;
            this.customerId = customerId;
            this.CustomerName = customerName;
        }

        public CustomerOrders()
        {
        }

        public int ExistingPoints { get; }
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