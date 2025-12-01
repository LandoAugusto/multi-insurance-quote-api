using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class VehicleFuelTypeRepository(MultiQuoteDbContext context) : DomainRepository<Core.Entities.VehicleFuelType>(context), 
        IVehicleFuelTypeRepository
    {
        public async Task<IEnumerable<Core.Entities.VehicleFuelType>?> GetAllAsync(RecordStatusEnum recordStatus)
        {
            var query =
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.VehicleFuelTypeId));
            return await query.ToListAsync();
        }
    }
}
