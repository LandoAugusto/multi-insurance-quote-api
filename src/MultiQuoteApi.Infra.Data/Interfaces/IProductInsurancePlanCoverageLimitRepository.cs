using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public  interface IProductInsurancePlanCoverageLimitRepository : IDomainRepository<ProductInsurancePlanCoverageLimit>
    {
        Task<ProductInsurancePlanCoverageLimit?> GetAsync(int productInsurancePlanCoverageId, int profileId, RecordStatusEnum recordStatus);
    }
}
