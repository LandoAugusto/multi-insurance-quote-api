using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductInsurancePlanCoverageRepository(MultiQuoteDbContext context) : DomainRepository<ProductInsurancePlanCoverage>(context)
        , IProductInsurancePlanCoverageRepository
    {

        public async Task<IEnumerable<ProductInsurancePlanCoverage>?> ListAsync(int productInsurancePlanId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.ProductInsurancePlanId.Equals(productInsurancePlanId)
                    && filtr.Status.Equals((int)recordStatus)),
                    includeProperties: source =>
                                    source
                                        .Include(item => item.ProductCoverage)
                                            .ThenInclude(item => item.Coverage)
                                            .ThenInclude(item => item.CoverageGroup),                                       
                    orderBy: item => item.OrderBy(y => y.ProductInsurancePlanId));

            return await query.ToListAsync();
        }
    }
}
