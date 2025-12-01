using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories;
using ProductApi.Infra.Data.Repositories;

namespace MultiQuoteApi.Infra.Data.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraData(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddDbContext<MultiQuoteDbContext>(
            options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
        )
        .AddRepositories();

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuProductRepository, MenuProductRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchTypeRepository, BranchTypeRepository>();
            services.AddScoped<IInsuranceBranchRepository, InsuranceBranchRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICoverageRepository, CoverageRepository>();
            services.AddScoped<IRecordStatusRepository, RecordStatusRepository>();
            services.AddScoped<IStateRepository, StateRepository>();            
            services.AddScoped<IInsuredTypeRepository, InsuredTypeRepository>();
            services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();            
            services.AddScoped<IInsuranceTypeRepository, InsuranceTypeRepository>();           
            services.AddScoped<IInsurerRepository, InsurerRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonTypeRepository, PersonTypeRepository>();
            services.AddScoped<IDriverTypeRepository, DriverTypeRepository>();            
            services.AddScoped<IBrokerRepository, BrokerRepository>();
            services.AddScoped<IQuotationStatusRepository, QuotationStatusRepository>();            
            services.AddScoped<IGenderRepository, GenderRepository>();            
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IProductAcceptanceRepository, ProductAcceptanceRepository>();
            services.AddScoped<IProductCalculationTypeRepository, ProductCalculationTypeRepository>();
            services.AddScoped<IProductQuestionnaireRepository, ProductQuestionnaireRepository>();
            services.AddScoped<IQuestionResponseRepository, QuestionResponseRepository>();            
            services.AddScoped<IVehicleBrandRepository, VehicleBrandRepository>();
            services.AddScoped<IVehicleFuelTypeRepository, VehicleFuelTypeRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
            services.AddScoped<IVehicleVersionRepository, VehicleVersionRepository>();
            services.AddScoped<IVehicleYearRepository, VehicleYearRepository>();
            return services;
        }
    }
}




