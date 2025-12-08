using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface ICoverageAppService
    {
        Task<IEnumerable<CoverageTypeOption>?> GetTypesAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<FranchiseTypeOption>?> GetFranchiseTypeAsync(int coverageTypeId, RecordStatusEnum recordStatus);
        Task<IEnumerable<FranchiseTypePercentageOption>?> GetFranchisePercentageAsync(int coverageTypeId, int franchiseTypeId, RecordStatusEnum recordStatus);
    }
}
