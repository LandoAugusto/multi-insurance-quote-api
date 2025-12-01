using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface ICoverageRepository : IDomainRepository<Coverage>
    {
        Task<IEnumerable<Coverage>?> GetAllAsync(RecordStatusEnum recordStatus);
    }
}
 