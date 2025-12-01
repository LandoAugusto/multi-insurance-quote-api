using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class BrokerRepository(MultiQuoteDbContext context) : DomainRepository<Broker>(context), 
        IBrokerRepository
    {
        public async Task<Broker?> GetByIdAsync(int  brokerId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.BrokerId.Equals(brokerId) && filtr.Status.Equals((int)recordStatus)),
                               includeProperties: source =>
                                    source
                                    .Include(item => item.Person),
                            orderBy: item => item.OrderBy(y => y.BrokerId));

            return await query.FirstOrDefaultAsync();
        }
    }
}
