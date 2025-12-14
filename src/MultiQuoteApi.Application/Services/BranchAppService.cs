using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Extensions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Application.Services
{
    internal class BranchAppService(IMapper mapper, IBranchRepository branchRepository, IBranchTypeRepository branchTypeRepository,
         IInsuranceBranchRepository insuranceBranchRepository) : IBranchAppService
    {
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly IBranchTypeRepository _branchTypeRepository = branchTypeRepository;
        private readonly IInsuranceBranchRepository _insuranceBranchRepository = insuranceBranchRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BranchTypeModel>?> ListBranchTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var entity = await _branchTypeRepository.ListAsync(recordStatusEnum);
            if (!entity.IsAny<BranchType>()) return null;

            return _mapper.Map<IEnumerable<BranchTypeModel>>(entity);
        }

        public async Task<IEnumerable<BranchModel>?> ListBranchAsync(int? brachTypeId, RecordStatusEnum recordStatusEnum)
        {
            var entity = await _branchRepository.ListAsync(brachTypeId, recordStatusEnum);
            if (!entity.IsAny<Branch>()) return null;

            return _mapper.Map<IEnumerable<BranchModel>>(entity);
        }
        public async Task<IEnumerable<InsuranceBranchModel>?> ListInsuranceBranchAsync(int? brachId, RecordStatusEnum recordStatusEnum)
        {
            var entity = await _insuranceBranchRepository.ListAsync(brachId, recordStatusEnum);
            if (!entity.IsAny<InsuranceBranch>()) return null;

            return _mapper.Map<IEnumerable<InsuranceBranchModel>>(entity);
        }
    }
}
