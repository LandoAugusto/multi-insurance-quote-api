using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IMenuProductRepository : IDomainRepository<MenuProduct>
    {
        Task<MenuProduct?> GetAsync(int code);
    }
}
