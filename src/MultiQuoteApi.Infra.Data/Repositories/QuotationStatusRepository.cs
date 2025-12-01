using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class QuotationStatusRepository(MultiQuoteDbContext context) : DomainRepository<QuotationStatus>(context),
        IQuotationStatusRepository
    {
        public async Task<IEnumerable<QuotationStatus>?> GetAllAsync(RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.QuotationStatusId));
            return await query.ToListAsync();
        }
    }
}
