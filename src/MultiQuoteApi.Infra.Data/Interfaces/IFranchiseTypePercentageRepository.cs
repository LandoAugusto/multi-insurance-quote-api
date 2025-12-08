using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IFranchiseTypePercentageRepository : IDomainRepository<FranchiseTypePercentage>
    {
        Task<IEnumerable<FranchiseTypePercentage>?> ListAsync(int coverageTypeId, int franchiseTypeId, RecordStatusEnum recordStatus);
    }
}
