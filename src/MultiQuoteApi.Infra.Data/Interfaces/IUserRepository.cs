using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IUserRepository :IDomainRepository<Users>   
    {
        Task<Users?> GetAsync(int userId, RecordStatusEnum recordStatus);
    }
}
