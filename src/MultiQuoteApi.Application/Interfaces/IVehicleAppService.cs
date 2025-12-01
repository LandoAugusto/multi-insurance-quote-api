using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IVehicleAppService
    {
        Task<IEnumerable<VehicleBrandModel>?> GetBrandAsync(string name, RecordStatusEnum recordStatus);
        Task<IEnumerable<VehicleModelModel>?> GetModelAsync(int vehicleBranchId, string? name, RecordStatusEnum recordStatus);
        Task<IEnumerable<VehicleVersionModel>?> GetVersionAsync(int vehicleModelId, string? name, RecordStatusEnum recordStatus);
        Task<IEnumerable<VehicleYearModel>?> GetYearAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<VehicleFuelTypeModel>?> GetFuelTypeAsync(RecordStatusEnum recordStatus);
    }
}
