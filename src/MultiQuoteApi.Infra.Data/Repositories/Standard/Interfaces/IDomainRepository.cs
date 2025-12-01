using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
