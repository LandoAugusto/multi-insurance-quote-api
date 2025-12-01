using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MultiQuoteApi.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
                      
            services.AddScoped<IMenuScreenAppService, MenuScreenAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ICommonAppService, CommonAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IVehicleAppService, VehicleAppService>();
            services.AddScoped<IQuotationAppService, QuotationAppService>();
            services.AddScoped<IBrokerAppService, BrokerAppService>();
        }
    }
}

