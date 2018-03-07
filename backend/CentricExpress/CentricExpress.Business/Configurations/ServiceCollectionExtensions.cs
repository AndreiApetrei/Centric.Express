using CentricExpress.Business.Domain;
using CentricExpress.Business.Services;
using CentricExpress.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.Business.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderFactory, OrderFactory>();

            services.AddScoped<IPointsCalculator, Points20ProcentOfTotalOrder>();
            services.AddScoped<IDiscountCalculator, DiscountCalculator>();
            services.AddScoped<ICustomerTypeProvider, CustomerTypeProvider>();
        }
    }
}