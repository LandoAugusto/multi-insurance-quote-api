using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class UserRepository(MultiQuoteDbContext context) : DomainRepository<Users>(context), IUserRepository
    {
        public async Task<Users?> GetAsync(int userId, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.UserId.Equals(userId)                                                
                                                && filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.UserId)));

            return query.FirstOrDefault();
        }
    }
}
