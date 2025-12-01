using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProfessionRepository(MultiQuoteDbContext context) : DomainRepository<Profession>(context),
        IProfessionRepository
    {
        public async Task<IEnumerable<Profession>?> ListAsync(string? name, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)
                                    && (string.IsNullOrEmpty(name) || filtr.Name.Contains(name))),
                            orderBy: item => item.OrderBy(y => y.ProfessionId)).Take(100);

            return await query.ToListAsync();
        }
    }
}
