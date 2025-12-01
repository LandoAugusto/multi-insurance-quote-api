using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace  MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IVehicleFuelTypeRepository : IDomainRepository<Core.Entities.VehicleFuelType>
    {
        Task<IEnumerable<Core.Entities.VehicleFuelType>?> GetAllAsync(RecordStatusEnum recordStatus);
    }
}

