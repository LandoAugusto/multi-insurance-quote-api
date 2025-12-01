using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public  interface IProfessionRepository : IDomainRepository<Profession>    
    {
        Task<IEnumerable<Profession>?> ListAsync(string? name, RecordStatusEnum recordStatus);
    }
}
