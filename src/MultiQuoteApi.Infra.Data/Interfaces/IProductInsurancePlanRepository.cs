using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IProductInsurancePlanRepository : IDomainRepository<ProductInsurancePlan>
    {
        Task<IEnumerable<ProductInsurancePlan>?> GetAsync(int productId, RecordStatusEnum recordStatus);
        Task<ProductInsurancePlan?> GetPlanAsync(int productId, int insurancePlanId, RecordStatusEnum recordStatus);
    }
}
