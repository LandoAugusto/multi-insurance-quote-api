using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class ContactRepository(MultiQuoteDbContext context) : DomainRepository<Contact>(context), IContactRepository
    {
    }
}
