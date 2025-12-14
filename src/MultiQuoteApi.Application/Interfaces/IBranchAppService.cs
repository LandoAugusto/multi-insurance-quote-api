using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IBranchAppService
    {
        Task<IEnumerable<BranchTypeModel>?> ListBranchTypeAsync(RecordStatusEnum recordStatusEnum);
        Task<IEnumerable<BranchModel>?> ListBranchAsync(int? brachTypeId, RecordStatusEnum recordStatusEnum);
        Task<IEnumerable<InsuranceBranchModel>?> ListInsuranceBranchAsync(int? brachId, RecordStatusEnum recordStatusEnum);
    }
}
