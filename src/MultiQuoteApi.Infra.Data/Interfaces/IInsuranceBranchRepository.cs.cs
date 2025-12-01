using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IInsuranceBranchRepository :IDomainRepository<InsuranceBranch>
    {
        Task<IEnumerable<InsuranceBranch>?> ListAsync(int? brachId, RecordStatusEnum recordStatus);
    }
}
