using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IPersonAppService
    {
        Task<PersonModel?> GetByDocumentAsync(int documentTypeId, string document);
    }
}
