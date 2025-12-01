using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Extensions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Application.Services
{
    internal class VehicleAppService(
            IMapper mapper,
            IVehicleVersionRepository vehicleVersionRepository,
            IVehicleModelRepository vehicleModelRepository,
            IVehicleBrandRepository vehicleBrandRepository,
            IVehicleYearRepository vehicleYearRepository,
            IVehicleFuelTypeRepository vehicleFuelTypeRepository) : IVehicleAppService
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository = vehicleBrandRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository = vehicleModelRepository;
        private readonly IVehicleVersionRepository _vehicleVersionRepository = vehicleVersionRepository;
        private readonly IVehicleYearRepository _vehicleYearRepository = vehicleYearRepository;
        private readonly IVehicleFuelTypeRepository _vehicleFuelTypeRepository = vehicleFuelTypeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<VehicleBrandModel>?> GetBrandAsync(string name, RecordStatusEnum recordStatus)
        {
            var entity = await _vehicleBrandRepository.GetSearchBrandAsync(name, recordStatus);
            if (!entity.IsAny<VehicleBrand>()) return null;

            return _mapper.Map<IEnumerable<VehicleBrandModel>>(entity);
        }

        public async Task<IEnumerable<VehicleModelModel>?> GetModelAsync(int vehicleBranchId, string? name, RecordStatusEnum recordStatus)
        {
            var entity = await _vehicleModelRepository.GetSearchModelAsync(vehicleBranchId, name, recordStatus);
            if (!entity.IsAny<VehicleModel>()) return null;

            return _mapper.Map<IEnumerable<VehicleModelModel>?>(entity);
        }

        public async Task<IEnumerable<VehicleVersionModel>?> GetVersionAsync(int vehicleModelId, string? name, RecordStatusEnum recordStatus)
        {
            var entity = await _vehicleVersionRepository.GetSearchVersionAsync(vehicleModelId, name, recordStatus);
            if (!entity.IsAny<VehicleVersion>()) return null;

            return _mapper.Map<IEnumerable<VehicleVersionModel>>(entity);
        }

        public async Task<IEnumerable<VehicleYearModel>?> GetYearAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _vehicleYearRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<VehicleYear>()) return null;

            return _mapper.Map<IEnumerable<VehicleYearModel>>(entity);
        }
        public async Task<IEnumerable<VehicleFuelTypeModel>?> GetFuelTypeAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _vehicleFuelTypeRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<VehicleFuelType>()) return null;

            return _mapper.Map<IEnumerable<VehicleFuelTypeModel>>(entity);
        }
    }
}
