using System;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IOrderService
    {
        Guid PlaceOrder(OrderDto order);
        OrderDto GetById(Guid id);
    }
}