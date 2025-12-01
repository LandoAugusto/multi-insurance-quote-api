using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;
namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class VehicleBrandRepository(MultiQuoteDbContext context) : DomainRepository<VehicleBrand>(context), IVehicleBrandRepository
    {
        public async Task<IEnumerable<VehicleBrand>?> GetSearchBrandAsync(string name, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Name.Contains(name) && filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.VehicleBrandId));

            return await query.ToListAsync();
        }
    }
}
