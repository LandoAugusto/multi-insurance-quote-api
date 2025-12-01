using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IBrokerAppService
    {
        Task<BrokerOptionModel?> GetByIdAsync(int brokerId, RecordStatusEnum recordStatus);
        Task CreateAsync(int userId, BrokerModel request);
    }
}
