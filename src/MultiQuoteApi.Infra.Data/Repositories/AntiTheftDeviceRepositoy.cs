using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class AntiTheftDeviceRepositoy(MultiQuoteDbContext context) : DomainRepository<AntiTheftDevice>(context)
        , IAntiTheftDeviceRepositoy
    {
        public async Task<IEnumerable<AntiTheftDevice>?> ListAsync(RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.AntiTheftDeviceId));

            return await query.ToListAsync();
        }
    }
}
