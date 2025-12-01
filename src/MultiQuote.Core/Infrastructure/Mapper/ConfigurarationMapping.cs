
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Core.Infrastructure.Mapper
{
    public class ConfigurarationMapping : AutoMapper.Profile
    {
        public ConfigurarationMapping()
        {
            CreateMap<MenuComponentModel, MenuComponent>().ReverseMap();
            CreateMap<MenuProductModel, MenuProduct>().ReverseMap();
            CreateMap<MenuScreenModel, MenuScreen>().ReverseMap();
            CreateMap<UserModel, Users>().ReverseMap();
            CreateMap<BranchModel, Branch>().ReverseMap();
            CreateMap<BrokerOptionModel, Broker>()
                 .ForPath(dest => dest.Person.Name, m => m.MapFrom(a => a.Name))
                .ReverseMap();            
            CreateMap<BrokerModel, Broker>().ReverseMap();
            CreateMap<BranchTypeModel, BranchType>().ReverseMap();
            CreateMap<InsuranceBranchModel, InsuranceBranch>().ReverseMap();
            CreateMap<ProductModel, Core.Entities.Product>().ReverseMap();
            CreateMap<CoverageModel, Coverage>().ReverseMap();                        
            CreateMap<AddressTypeModel, AddressType>().ReverseMap();
            CreateMap<DriverTypeOptionModel, DriverType>().ReverseMap();            
            CreateMap<InsuredTypeModel, InsuredType>().ReverseMap();
            CreateMap<RecordStatusModel, RecordStatus>().ReverseMap();            
            CreateMap<StateModel, State>().ReverseMap();
            CreateMap<InsuranceTypeModel, InsuranceType>().ReverseMap();            
            CreateMap<CalculationTypeModel, CalculationType>().ReverseMap();
            CreateMap<InsurerModel, Insurer>().ReverseMap();            
            CreateMap<PersonTypeModel, PersonType>().ReverseMap();
            CreateMap<QuotationStatusModel, QuotationStatus>().ReverseMap();          
            CreateMap<GenderOptionModel, Gender>().ReverseMap();
            CreateMap<ProfessionModel, Profession>().ReverseMap();          
            CreateMap<MaritalStatusModel, MaritalStatus>().ReverseMap();
            CreateMap<ProductAcceptanceModel, ProductAcceptance>().ReverseMap();
            CreateMap<VehicleBrandModel, VehicleBrand>().ReverseMap();  
            CreateMap<VehicleFuelTypeModel, VehicleFuelType>().ReverseMap();    
            CreateMap<VehicleModelModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleVersionModel, VehicleVersion>().ReverseMap();  
            CreateMap<VehicleYearModel, VehicleYear>().ReverseMap();            
            CreateMap<QuestionnaireModel, Question>().ReverseMap();
            CreateMap<ResponseModel, Response>().ReverseMap();
        }
    }
}
