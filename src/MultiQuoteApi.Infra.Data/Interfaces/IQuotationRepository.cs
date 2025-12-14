using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public  interface IQuotationRepository : IDomainRepository<Quotation>
    {
    }
}
