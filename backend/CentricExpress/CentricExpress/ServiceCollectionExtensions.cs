using CentricExpress.Business.Configurations;
using CentricExpress.DataAccess.Configurations.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIoc(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);

            services.AddBusiness();
        }
    }
}
