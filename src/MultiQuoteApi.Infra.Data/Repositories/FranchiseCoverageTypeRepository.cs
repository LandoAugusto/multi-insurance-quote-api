using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class FranchiseCoverageTypeRepository(MultiQuoteDbContext context) : DomainRepository<FranchiseCoverageType>(context)
        , IFranchiseCoverageTypeRepository
    {
        public async Task<IEnumerable<FranchiseCoverageType>?> ListAsync(int coverageTypeId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.CoverageTypeId.Equals(coverageTypeId)
                    && filtr.Status.Equals((int)recordStatus)),
                     includeProperties: source =>
                                    source
                                    .Include(item => item.FranchiseType),
                    orderBy: item => item.OrderBy(y => y.CoverageTypeId));

            return await query.ToListAsync();
        }
    }
}
