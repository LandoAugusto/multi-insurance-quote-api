using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductInsurancePlanCoverageLimitRepository(MultiQuoteDbContext context) : DomainRepository<ProductInsurancePlanCoverageLimit>(context),
        IProductInsurancePlanCoverageLimitRepository
    {

        public async Task<ProductInsurancePlanCoverageLimit?> GetAsync(int productInsurancePlanCoverageId, int profileId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                           filter: (filtr => filtr.ProductInsurancePlanCoverageId.Equals(productInsurancePlanCoverageId)
                                               && filtr.ProfileId.Equals(profileId)
                                               && filtr.Status.Equals((int)recordStatus)),
                           orderBy: item => item.OrderBy(y => y.ProductInsurancePlanCoverageId));

            return await query.FirstOrDefaultAsync();
        }
    }
}
    