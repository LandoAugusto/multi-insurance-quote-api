using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IQuotationAppService
    {
        Task<CalculateValidityModel> CalculateValidityAsync(int profileId, CalculateValidityFilterModel request);
    }
}
