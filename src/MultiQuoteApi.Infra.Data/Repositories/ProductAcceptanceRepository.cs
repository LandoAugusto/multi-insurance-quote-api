using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductAcceptanceRepository(MultiQuoteDbContext context) : DomainRepository<ProductAcceptance>(context), IProductAcceptanceRepository
    {
        public async Task<ProductAcceptance?> GetAsync(int productId, int profileId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.ProductId.Equals(productId)
                                                && filtr.ProfileId.Equals(profileId)
                                                && filtr.Status.Equals((int)recordStatus)),
                             includeProperties: source =>
                                    source
                                    .Include(item => item.Product)                                    
                                    .ThenInclude(item => item.InsuranceBranch),
                            orderBy: item => item.OrderBy(y => y.ProductId));

            return await query.FirstOrDefaultAsync();
        }
    }
}
