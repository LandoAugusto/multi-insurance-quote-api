using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface ITrackerRepository : IDomainRepository<Tracker>
    {
        Task<IEnumerable<Tracker>?> ListAsync(RecordStatusEnum recordStatus);
    }
}
    