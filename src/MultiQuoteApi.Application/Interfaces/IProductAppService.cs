using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId, RecordStatusEnum recordStatus);
        Task<IEnumerable<CalculationTypeModel>?> GetCalculationTypeAsync(int productId, int profileId, RecordStatusEnum recordStatus);
        Task<IEnumerable<QuestionnaireModel>?> GetQuestionnaireAsync(int producId, RecordStatusEnum recordStatus);
        Task<IEnumerable<InsurancePlanOptionModel>?> GetInsurancePlanAsync(int productVersionId, RecordStatusEnum recordStatus);
        Task<IEnumerable<GroupModel>?> GetInsurancePlanCoverageLimitsAsync(int productId, int insurancePlanId, int profileId, RecordStatusEnum recordStatus);
        Task<IEnumerable<ServiceTypeModel>?> GetCoveraTypeServicesAsync(
             int productId, int coverageTypeId, RecordStatusEnum recordStatus);
    }
}
        