using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class CoverageTypeRepository(MultiQuoteDbContext context) : DomainRepository<CoverageType>(context)
        , ICoverageTypeRepository
    {
        public async Task<IEnumerable<CoverageType>?> ListAsync(RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.CoverageTypeId));

            return await query.ToListAsync();
        }
    }
}
