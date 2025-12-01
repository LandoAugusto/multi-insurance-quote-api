using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IDriverTypeRepository : IDomainRepository<DriverType>
    {
        Task<IEnumerable<DriverType>?> ListAsync(RecordStatusEnum recordStatus);
    }
}
