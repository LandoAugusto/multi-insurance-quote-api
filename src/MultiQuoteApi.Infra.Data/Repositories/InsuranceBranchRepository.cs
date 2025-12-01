using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class InsuranceBranchRepository(MultiQuoteDbContext context) : DomainRepository<InsuranceBranch>(context), IInsuranceBranchRepository
    {
        public async Task<IEnumerable<InsuranceBranch>?> ListAsync(int? brachId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => (brachId == null || filtr.BranchId.Equals(brachId))
                            && filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.InsuranceBranchId));

            return await query.ToListAsync();
        }
    }
}
