using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.Repositories
{
    public interface ICustomerOrdersRepository
    {
        CustomerOrders GetByCustomerId(Guid customerId);
        void Save(CustomerOrders customerOrders);
        Order GetOrderById(Guid id);
    }
}