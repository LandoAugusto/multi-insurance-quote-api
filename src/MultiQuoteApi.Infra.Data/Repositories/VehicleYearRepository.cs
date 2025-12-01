
using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Repositories.Standard;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class VehicleYearRepository(MultiQuoteDbContext context) : DomainRepository<VehicleYear>(context), IVehicleYearRepository
    {
        public async Task<IEnumerable<VehicleYear>?> GetAllAsync(RecordStatusEnum recordStatus)
        {
            var query =
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderByDescending(y => y.Year));
            return await query.ToListAsync();
        }
    }
}
