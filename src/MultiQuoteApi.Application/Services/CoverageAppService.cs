using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Extensions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Application.Services
{
    internal class CoverageAppService(
        IMapper mapper, ICoverageTypeRepository coverageTypeRepository,
        IFranchiseCoverageTypeRepository franchiseCoverageTypeRepository,
        IFranchiseTypePercentageRepository franchiseTypePercentageRepository) :
        ICoverageAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICoverageTypeRepository _coverageTypeRepository = coverageTypeRepository;
        private readonly IFranchiseCoverageTypeRepository _franchiseCoverageTypeRepository = franchiseCoverageTypeRepository;
        private readonly IFranchiseTypePercentageRepository _franchiseTypePercentageRepository = franchiseTypePercentageRepository;

        public async Task<IEnumerable<CoverageTypeOption>?> GetTypesAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _coverageTypeRepository.ListAsync(recordStatus);
            if (!entity.IsAny<CoverageType>()) return null;

            return _mapper.Map<IEnumerable<CoverageTypeOption>>(entity);
        }

        public async Task<IEnumerable<FranchiseTypeOption>?> GetFranchiseTypeAsync(int coverageTypeId, RecordStatusEnum recordStatus)
        {
            var entity = await _franchiseCoverageTypeRepository.ListAsync(coverageTypeId, recordStatus);
            if (!entity.IsAny<FranchiseCoverageType>()) return null;

            return [.. entity.ToList().Select(item =>
            {
                return _mapper.Map<FranchiseTypeOption>(item.FranchiseType);
            })];

        }

        public async Task<IEnumerable<FranchiseTypePercentageOption>?> GetFranchisePercentageAsync(int coverageTypeId, int franchiseTypeId, RecordStatusEnum recordStatus)
        {
            var entity = await _franchiseTypePercentageRepository.ListAsync(coverageTypeId, franchiseTypeId, recordStatus);
            if (!entity.IsAny<FranchiseTypePercentage>()) return null;

            return _mapper.Map<IEnumerable<FranchiseTypePercentageOption>>(entity);           
        }
    }
}
