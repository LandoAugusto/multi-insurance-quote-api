using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IRecordStatusRepository : IDomainRepository<RecordStatus>
    {
    }
}
