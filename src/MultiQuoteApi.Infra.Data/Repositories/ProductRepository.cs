using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ProductRepository(MultiQuoteDbContext context) : DomainRepository<Core.Entities.Product>(context)
        , IProductRepository
    {
        public async Task<IEnumerable<Core.Entities.Product>?> ListAsync(RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.ProductId));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Product>?> ListBranchAsync(int insurancebranchId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.InsuranceBranchId.Equals(insurancebranchId) && filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.ProductId));

            return await query.ToListAsync();
        }
    }
}
