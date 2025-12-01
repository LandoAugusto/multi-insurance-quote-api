using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public  interface IProductAcceptanceRepository : IDomainRepository<ProductAcceptance>
    {
        Task<ProductAcceptance?> GetAsync(int productId, int profileId, RecordStatusEnum recordStatus);
    }
}
