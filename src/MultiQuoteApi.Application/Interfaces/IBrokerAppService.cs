using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IBrokerAppService
    {
        Task<BrokerDetailsModel?> GetDetailsByIdAsync(int brokerId, RecordStatusEnum recordStatus);
        Task<BrokerOptionModel?> GetByIdAsync(int brokerId, RecordStatusEnum recordStatus);
        Task CreateAsync(BrokerModel request);
        Task CreateUserAsync(int userId, int brokerId, BrokerUserModel request);
    }
}
