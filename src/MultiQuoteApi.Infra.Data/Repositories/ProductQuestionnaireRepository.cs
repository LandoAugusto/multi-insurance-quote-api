using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace ProductApi.Infra.Data.Repositories
{
    internal class ProductQuestionnaireRepository(MultiQuoteDbContext context) : DomainRepository<ProductQuestionnaire>(context),
        IProductQuestionnaireRepository
    {
        public async Task<IEnumerable<ProductQuestionnaire>?> GetAsync(int producId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.ProductId.Equals(producId)
                    && filtr.Status.Equals((int)recordStatus)),
                     includeProperties: source =>
                                    source
                                    .Include(item => item.Question),
                    orderBy: item => item.OrderBy(y => y.Order));

            return await query.ToListAsync();
        }
    }
}
