using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;
using MultiQuoteApi.Core.Entities;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IProductCalculationTypeRepository : IDomainRepository<ProductCalculationType>
    {
        Task<IEnumerable<ProductCalculationType>?> ListAsync(int productId, int profileId, RecordStatusEnum recordStatus);

        Task<ProductCalculationType?> GetAsync(int productId, int profileId, int calculationTypeId,
        RecordStatusEnum recordStatus);
    }
}
