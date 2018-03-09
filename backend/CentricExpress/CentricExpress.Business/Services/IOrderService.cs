using System;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IOrderService
    {
        OrderPaymentSummary PlaceOrder(OrderDto order, Guid customerId);
        OrderDto GetById(Guid guid, Guid id);
    }
}