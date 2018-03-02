using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services.Implementations
{
    public interface IOrderFactory
    {
        Order CreateOrder(OrderDto orderDto);
    }
}