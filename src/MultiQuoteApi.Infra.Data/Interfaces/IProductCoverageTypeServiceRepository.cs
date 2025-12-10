using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IProductCoverageTypeServiceRepository : IDomainRepository<ProductCoverageTypeService>
    {
        Task<IEnumerable<ProductCoverageTypeService>?> ListAsync(int productId, int coverageTypeId, RecordStatusEnum recordStatus);
    }
}
