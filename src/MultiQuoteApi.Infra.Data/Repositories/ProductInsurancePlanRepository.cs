using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductInsurancePlanRepository(MultiQuoteDbContext context) : DomainRepository<ProductInsurancePlan>(context)
        , IProductInsurancePlanRepository
    {
        public async Task<IEnumerable<ProductInsurancePlan>?> GetAsync(int productId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.Product.ProductId.Equals(productId)
                    && filtr.Status.Equals((int)recordStatus)),
                    includeProperties: source =>
                                    source
                                        .Include(item => item.InsurancePlan)
                                        .ThenInclude(item => item.InsurancePlanType),
                    orderBy: item => item.OrderBy(y => y.ProductInsurancePlanId));

            return await query.ToListAsync();
        }
    }
}
