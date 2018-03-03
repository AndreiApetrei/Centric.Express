using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByOrderId(Guid id); 
    }
} 