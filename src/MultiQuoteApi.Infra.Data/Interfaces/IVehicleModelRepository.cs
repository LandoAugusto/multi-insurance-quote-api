using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IVehicleModelRepository : IDomainRepository<VehicleModel>
    {
        Task<IEnumerable<VehicleModel>?> GetSearchModelAsync(int vehicleBranchId, string? name, RecordStatusEnum recordStatus);
    }
}

