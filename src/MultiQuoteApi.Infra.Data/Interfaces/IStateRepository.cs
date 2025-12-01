using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IStateRepository :IDomainRepository<State>
    {
        Task<IEnumerable<State>?> ListAsync( RecordStatusEnum recordStatus, string? stateId = null);
    }
}
