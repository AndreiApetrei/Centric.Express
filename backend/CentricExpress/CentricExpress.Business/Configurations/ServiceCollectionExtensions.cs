using CentricExpress.Business.Handlers;
using CentricExpress.Business.Handlers.Implementations;
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
