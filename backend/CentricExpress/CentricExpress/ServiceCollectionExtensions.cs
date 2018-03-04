using CentricExpress.Business.Configurations;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Validators;
using CentricExpress.DataAccess.Configurations.IoC;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIoc(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddBusiness();
            services.AddFluentValidationForDtos();
        }

        private static void AddFluentValidationForDtos(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<ItemDto>, ItemDtoValidator>();
            services.AddSingleton<IValidator<OrderLineDto>, OrderLineDtoValidator>();
            services.AddSingleton<IValidator<OrderDto>, OrderDtoValidator>();
        }
    }
}
