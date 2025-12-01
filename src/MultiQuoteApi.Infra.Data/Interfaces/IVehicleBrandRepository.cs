using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;


namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IVehicleBrandRepository : IDomainRepository<VehicleBrand>
    {
        Task<IEnumerable<VehicleBrand>?> GetSearchBrandAsync(string name, RecordStatusEnum recordStatus);        
    }
}
