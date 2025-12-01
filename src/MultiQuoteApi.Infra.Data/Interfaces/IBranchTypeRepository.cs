using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IBranchTypeRepository : IDomainRepository<BranchType>    
    {
        Task<IEnumerable<BranchType>?> ListAsync(RecordStatusEnum recordStatusEnum);
    }
}
