using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Repositories.Standard;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class VehicleVersionRepository(MultiQuoteDbContext context) : DomainRepository<VehicleVersion>(context), IVehicleVersionRepository
    {
        public async Task<IEnumerable<VehicleVersion>?> GetSearchVersionAsync(int vehicleModelId, string? name, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                           filter: (filtr => filtr.VehicleModelId == vehicleModelId
                           && (name == null || filtr.Name.Contains(name))
                           && filtr.Status.Equals((int)recordStatus)),
                           orderBy: item => item.OrderBy(y => y.VehicleModelId));

            return await query.ToListAsync();
        }
    }
}
