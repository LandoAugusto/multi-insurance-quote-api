using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class BranchRepository(MultiQuoteDbContext context) : DomainRepository<Branch>(context), IBranchRepository
    {
        public async Task<IEnumerable<Branch>?> ListAsync(int? brachTypeId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => (brachTypeId == null || filtr.BranchTypeId.Equals(brachTypeId))
                            && filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.BranchTypeId));

            return await query.ToListAsync();
        }
    }
}
