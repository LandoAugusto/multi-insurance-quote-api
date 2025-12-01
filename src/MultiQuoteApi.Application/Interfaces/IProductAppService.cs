using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId, RecordStatusEnum recordStatus);
        Task<IEnumerable<CalculationTypeModel>?> GetCalculationTypeAsync(int productId, int profileId, RecordStatusEnum recordStatus);
        Task<IEnumerable<QuestionnaireModel>?> GetQuestionnaireAsync(int producId, RecordStatusEnum recordStatus);
    }
}
