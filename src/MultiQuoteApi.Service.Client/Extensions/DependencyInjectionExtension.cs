using Microsoft.Extensions.DependencyInjection;
using MultiQuoteApi.Service.Client.Interfaces;
using MultiQuoteApi.Service.Client.Services;

namespace MultiQuoteApi.Service.Client.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServiceClient(this IServiceCollection services)
        {
            services.AddScoped<IZipCodeService, ZipCodeService>();            
            return services;
        }
    }
}
