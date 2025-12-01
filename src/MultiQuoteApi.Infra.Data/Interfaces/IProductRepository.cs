using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IProductRepository : IDomainRepository<Core.Entities.Product>
    {
        Task<IEnumerable<Core.Entities.Product>?> ListAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<Core.Entities.Product>?> ListBranchAsync(int insurancebranchId, RecordStatusEnum recordStatus);
    }
}

