using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IBrokerRepository : IDomainRepository<Broker>
    {
        Task<Broker?> GetByIdAsync(int brokerId, RecordStatusEnum recordStatus);
    }
}
