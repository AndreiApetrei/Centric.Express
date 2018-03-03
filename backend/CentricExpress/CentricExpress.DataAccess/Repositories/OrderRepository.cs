using System;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CentricExpress.DataAccess.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext, ILogger<Repository<Order>> logger) : base(appDbContext, logger)
        {
        }

        public Order GetByOrderId(Guid id)
        {
            return ExecuteWithLogging(() =>
                AppDbContext.Set<Order>().Where(order => order.Id == id).Include(order => order.OrderLines)
                    .FirstOrDefault());
        }
    }
}