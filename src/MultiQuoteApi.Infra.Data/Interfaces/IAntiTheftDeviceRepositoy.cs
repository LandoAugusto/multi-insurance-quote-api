using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IAntiTheftDeviceRepositoy : IDomainRepository<AntiTheftDevice>
    {
        Task<IEnumerable<AntiTheftDevice>?> ListAsync(RecordStatusEnum recordStatus);
    }
}
    