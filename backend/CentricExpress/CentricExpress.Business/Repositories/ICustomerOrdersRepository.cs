using System;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Services.Implementations;

namespace CentricExpress.Business.Repositories
{
    public interface ICustomerOrdersRepository
    {
        CustomerOrders GetByCustomerId(Guid customerId);
        void Save(CustomerOrders customerOrders);
        Order GetOrderById(Guid id);
    }
}