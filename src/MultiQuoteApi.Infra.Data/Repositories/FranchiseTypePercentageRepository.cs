using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class FranchiseTypePercentageRepository(MultiQuoteDbContext context) : DomainRepository<FranchiseTypePercentage>(context),
        IFranchiseTypePercentageRepository
    {
        public async Task<IEnumerable<FranchiseTypePercentage>?> ListAsync(int coverageTypeId, int franchiseTypeId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.FranchiseCoverageType.CoverageTypeId.Equals(coverageTypeId)
                          && filtr.FranchiseCoverageType.FranchiseTypeId.Equals(franchiseTypeId)
                          && filtr.Status.Equals((int)recordStatus)),                     
                    orderBy: item => item.OrderBy(y => y.FranchiseCoverageTypeId));

            return await query.ToListAsync();
        }
    }
}
