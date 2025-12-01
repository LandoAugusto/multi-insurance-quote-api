using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiQuoteApi.Application.Extensions;
using MultiQuoteApi.Core.Infrastructure.Configuration;
using MultiQuoteApi.Infra.Data.Extensions;
using MultiQuoteApi.Infra.Identity.Extensions;
using MultiQuoteApi.Service.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiQuoteApi.Infra.IoC
{
    public static class DependencyInjectionExtension
    {
        public static void AddIoC(this IServiceCollection services, IConfiguration configuration,ApiConfig apiConfig)
        {
            services.AddAppServices();
            services.AddInfraData(configuration);
            services.AddIdentityIoC(configuration, apiConfig);
            services.AddServiceClient();
        }
    }
}
