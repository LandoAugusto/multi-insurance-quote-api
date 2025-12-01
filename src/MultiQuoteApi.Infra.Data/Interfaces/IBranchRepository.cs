using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IBranchRepository : IDomainRepository<Branch>
    {
        Task<IEnumerable<Branch>?> ListAsync(int? brachTypeId, RecordStatusEnum recordStatus);
    }
}
