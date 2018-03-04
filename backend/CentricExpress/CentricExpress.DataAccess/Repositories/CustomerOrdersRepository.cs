using System;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CentricExpress.DataAccess.Repositories
{
    public class CustomerOrdersRepository : ICustomerOrdersRepository
    {
        private readonly AppDbContext appDbContext;

        public CustomerOrdersRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public CustomerOrders GetByCustomerId(Guid customerId)
        {
            var customer = appDbContext.Set<Customer>().Find(customerId);
            return customer == null ? null : new CustomerOrders(customerId, GetExistingPoints(customerId), GetCustomerName(customer));
        }

        private string GetCustomerName(Customer customer)
        {
            return customer == null ? string.Empty : customer.FullName;
        }

        private int GetExistingPoints(Guid customerId)
        {
            return appDbContext.Set<CustomerPoints>().Where(points => points.CustomerId == customerId).Sum(points => points.Points);
        }

        public void Save(CustomerOrders customerOrders)
        {
            appDbContext.Set<Order>().Add(customerOrders.NewOrder);
            appDbContext.Set<CustomerPoints>().Add(customerOrders.NewPoints);
        }

        public Order GetOrderById(Guid id)
        {
            return appDbContext.Set<Order>().Where(order => order.Id == id).Include(order => order.OrderLines)
                .FirstOrDefault();
        }
    }
}