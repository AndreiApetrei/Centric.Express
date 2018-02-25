using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IOrderService
    {
        void PlaceOrder(OrderDto order);
    }
}