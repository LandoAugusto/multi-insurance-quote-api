using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class PersonRepository(MultiQuoteDbContext context) : DomainRepository<Person>(context),
        IPersonRepository
    {
        public async Task<IEnumerable<Person>?> GetPersonAsync(int personTypeId, string document ,RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                            filter: (

                            filtr => filtr.PersonTypeId.Equals(personTypeId)
                             && filtr.Document.Equals(document)                               
                            && filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.PersonId));

            return await query.ToListAsync();
        }
    }
}
