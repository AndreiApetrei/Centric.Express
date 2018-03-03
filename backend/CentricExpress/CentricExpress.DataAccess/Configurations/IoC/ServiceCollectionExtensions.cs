using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using CentricExpress.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.DataAccess.Configurations.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IRepository<Picture>, Repository<Picture>>();

            services.AddTransient<ICustomerOrdersRepository, CustomerOrdersRepository>();

        }
    }
}
