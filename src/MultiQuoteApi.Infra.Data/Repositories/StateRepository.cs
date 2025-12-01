using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class StateRepository(MultiQuoteDbContext context) : DomainRepository<State>(context), IStateRepository
    {
        public async Task<IEnumerable<State>?> ListAsync(RecordStatusEnum recordStatus, string? stateId = null)
        {
            var query = GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)
                            && string.IsNullOrEmpty(stateId) || stateId.Equals(filtr.Initials)),
                            orderBy: item => item.OrderBy(y => y.StateId));

            return await query.ToListAsync();
        }
    }
}
