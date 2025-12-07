using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IProductInsurancePlanCoverageRepository : IDomainRepository<ProductInsurancePlanCoverage>
    {
        Task<IEnumerable<ProductInsurancePlanCoverage>?> ListAsync(int productInsurancePlanId, RecordStatusEnum recordStatus);
    }
}
