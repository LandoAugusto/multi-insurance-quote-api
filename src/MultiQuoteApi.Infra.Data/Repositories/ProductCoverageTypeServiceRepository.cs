using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;
using Nest;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductCoverageTypeServiceRepository(MultiQuoteDbContext context) : DomainRepository<ProductCoverageTypeService>(context),
        IProductCoverageTypeServiceRepository
    {
        public async Task<IEnumerable<ProductCoverageTypeService>?> ListAsync(int productId, int coverageTypeId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                           filter: (filtr => filtr.ProductId.Equals(productId)
                                    && filtr.CoverageTypeId.Equals(coverageTypeId)
                                    && filtr.Status.Equals((int)recordStatus)),
                                    includeProperties: source =>
                                    source
                                    .Include(item => item.ServiceOptionPlan)
                                    .Include(item => item.ServiceOption)
                                    .ThenInclude(item => item.ServiceType),
                           orderBy: item => item.OrderBy(y => y.ProductCoverageTypeServiceId));

            return await query.ToListAsync();
        }
    }
}
