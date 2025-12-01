using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace  MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IVehicleVersionRepository : IDomainRepository<VehicleVersion>
    {
        Task<IEnumerable<VehicleVersion>?> GetSearchVersionAsync(int vehicleBranchId, string? name, RecordStatusEnum recordStatus);
    }
}

