using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductCalculationTypeRepository(MultiQuoteDbContext context) : DomainRepository<ProductCalculationType>(context),
        IProductCalculationTypeRepository
    {
        public async Task<IEnumerable<ProductCalculationType>?> ListAsync(int productId, int profileId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.ProductId.Equals(productId) && filtr.ProfileId.Equals(profileId) && filtr.Status.Equals((int)recordStatus)),
                    includeProperties: source =>
                                    source
                                    .Include(item => item.CalculationType),
                    orderBy: item => item.OrderBy(y => y.CalculationTypeId));

            return await query.ToListAsync();
        }

        public async Task<ProductCalculationType?> GetAsync(int productId, int profileId, int calculationTypeId,
            RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.ProductId.Equals(productId)
                    && filtr.ProfileId.Equals(profileId) && filtr.Status.Equals((int)recordStatus)
                    && filtr.CalculationTypeId.Equals(calculationTypeId)),
                    includeProperties: source =>
                                    source
                                    .Include(item => item.CalculationType),
                    orderBy: item => item.OrderBy(y => y.CalculationTypeId));

            return await query.FirstOrDefaultAsync();
        }
    }
}
