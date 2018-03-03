using System;
using CentricExpress.Business.Services.Implementations;

namespace CentricExpress.Business.Repositories
{
    public interface ICustomerOrdersRepository
    {
        CustomerOrders GetByCustomerId(Guid customerId);
        void Save(CustomerOrders customerOrders);
    }
}