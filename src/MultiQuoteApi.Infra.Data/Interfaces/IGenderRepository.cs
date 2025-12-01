using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IGenderRepository : IDomainRepository<Gender>
    {
        Task<IEnumerable<Gender>?> ListAsync(RecordStatusEnum recordStatus);
    }
}
