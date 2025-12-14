using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IQuotationAppService
    {
        Task CreatedAsync(int inclusionUserId, QuotationModel request);
        Task<CalculateValidityModel> CalculateValidityAsync(int profileId, CalculateValidityFilterModel request);
    }
}
