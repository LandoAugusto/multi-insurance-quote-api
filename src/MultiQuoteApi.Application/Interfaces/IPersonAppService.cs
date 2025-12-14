using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IPersonAppService
    {
        Task<PersonModel?> GetByDocumentAsync(int documentTypeId, string document);
        Task<int> CreatePersonAsync(int userId, BasePersonModel model);
        Task<(int BrokerId, int PersonId)> CreateBrokerAsync(int userId, BrokerModel model);        
    }
}
