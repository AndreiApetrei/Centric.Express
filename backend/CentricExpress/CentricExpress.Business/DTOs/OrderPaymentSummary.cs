using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.DTOs
{
    public class OrderPaymentSummary
    {
        private OrderPaymentSummary()
        {
            TotalAmount = Money.Zero;
        }

        public Guid OrderId { get; set; }
        public Money TotalAmount { get; set; }
        public int NewPoints { get; set; }
        public int TotalPoints { get; set; }
        public string CustomerName { get; set; }

        public static OrderPaymentSummary FromCustomerOrders(CustomerOrders customerOrders)
        {
            if (customerOrders?.NewOrder == null)
            {
                return new OrderPaymentSummary();
            }

            return new OrderPaymentSummary
            {
                OrderId = customerOrders.NewOrder.Id,
                TotalAmount = customerOrders.NewOrder.TotalAmount,
                NewPoints = customerOrders.NewPoints.Points,
                TotalPoints = customerOrders.TotalPoints,
                CustomerName = customerOrders.CustomerName
            };
        }
    }
}