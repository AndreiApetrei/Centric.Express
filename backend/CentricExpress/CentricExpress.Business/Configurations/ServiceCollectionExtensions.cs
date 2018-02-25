using CentricExpress.Business.Services;
using CentricExpress.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.Business.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
        }
    }
}
