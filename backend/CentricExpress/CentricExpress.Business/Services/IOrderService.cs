using System;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IOrderService
    {
        OrderPaymentSummary PlaceOrder(OrderDto order);
        OrderDto GetById(Guid id);
    }
}