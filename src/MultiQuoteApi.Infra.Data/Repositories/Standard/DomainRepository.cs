using MultiQuoteApi.Core.Entities.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MultiQuoteApi.Infra.Data.Repositories.Standard
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                             IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
