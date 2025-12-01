using MultiQuoteApi.Core.Infrastructure.Configuration;

namespace MultiQuoteApi.Core.Infrastructure.Interfaces
{
    public interface IApiWorkContext
    {
        BaseHeader BaseHeader { get; set; }
    }
}
