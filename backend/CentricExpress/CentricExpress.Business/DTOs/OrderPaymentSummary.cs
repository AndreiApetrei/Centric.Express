using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.DTOs
{
    public class OrderPaymentSummary
    {
        public static readonly OrderPaymentSummary NoCustoemrFound =
            new OrderPaymentSummary() {Status = Status.NoCustomerFound};

        private OrderPaymentSummary()
        {
            OrderAmount = Money.Zero;
            Status = Status.OrderCreated;
        }

        public Guid OrderId { get; set; }
        public Money OrderAmount { get; set; }
        public int NewPoints { get; set; }
        public int TotalPoints { get; set; }
        public string CustomerName { get; set; }
        public Status Status { get; private set; }
        public Money Discount { get; set; }
        public Money PayAmount { get; set; }

        public static OrderPaymentSummary FromCustomerOrders(CustomerOrders customerOrders)
        {
            if (customerOrders?.NewOrder == null)
            {
                return new OrderPaymentSummary();
            }

            return new OrderPaymentSummary
            {
                OrderId = customerOrders.NewOrder.Id,
                NewPoints = customerOrders.NewPoints.Points,
                TotalPoints = customerOrders.TotalPoints,
                CustomerName = customerOrders.CustomerName,
                OrderAmount = customerOrders.NewOrder.TotalAmount,
                Discount = customerOrders.NewOrder.Discount,
                PayAmount = customerOrders.NewOrder.PayAmount,
            };
        }
    }

    public enum Status
    {
        OrderCreated,
        NoCustomerFound
    }
}