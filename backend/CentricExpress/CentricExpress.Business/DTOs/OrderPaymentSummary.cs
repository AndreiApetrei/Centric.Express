using System;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Services.Implementations;

namespace CentricExpress.Business.DTOs
{
    public class OrderPaymentSummary
    {
        public Guid OrderId { get; }
        public Money TotalAmount { get; }

        private OrderPaymentSummary(Guid orderId, Money totalAmount)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
        }

        public static OrderPaymentSummary FromCustomerOrders(CustomerOrders customerOrders)
        {
            return customerOrders?.NewOrder == null
                ? new OrderPaymentSummary(Guid.Empty, Money.Zero)
                : new OrderPaymentSummary(customerOrders.NewOrder.Id, customerOrders.NewOrder.TotalAmount);
        }
    }
}