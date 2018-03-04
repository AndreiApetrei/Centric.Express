using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Domain
{
    public interface IOrderFactory
    {
        Order CreateOrder(OrderDto orderDto);
    }
}