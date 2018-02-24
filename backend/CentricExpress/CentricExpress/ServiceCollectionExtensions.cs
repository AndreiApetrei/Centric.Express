using CentricExpress.Business.Configurations;
using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using CentricExpress.DataAccess.Configurations.IoC;
using CentricExpress.DataAccess.Repositories;
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
