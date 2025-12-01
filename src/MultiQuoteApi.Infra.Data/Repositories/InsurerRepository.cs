using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class InsurerRepository(MultiQuoteDbContext context) : DomainRepository<Insurer>(context), IInsurerRepository
    {
        public async Task<IEnumerable<Insurer>?> GetAllAsync(RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.InsurerId));

            return await query.ToListAsync();
        }
    }
}
