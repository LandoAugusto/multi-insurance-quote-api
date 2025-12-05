using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IPersonRepository : IDomainRepository<Person>
    {
        Task<IEnumerable<Person>?> GetPersonAsync(int personTypeId, string document, RecordStatusEnum recordStatus);
        Task<Person?> GetByDocumentAsync(int personTypeId, string document);
    }
}
