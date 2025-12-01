using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IInsurerRepository : IDomainRepository<Insurer>
    {
        Task<IEnumerable<Insurer>?> GetAllAsync(RecordStatusEnum recordStatus);
    }
}
