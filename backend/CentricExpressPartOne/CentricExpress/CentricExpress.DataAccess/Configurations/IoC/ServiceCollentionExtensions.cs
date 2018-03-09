using CentricExpress.Business.Repositories;
using CentricExpress.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.DataAccess.Configurations.IoC
{
    public static class ServiceCollentionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
