using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace MultiQuoteApi.Service.Client.Handlers
{
    public class AutenticacaoTokenHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _httpContextAccessor.HttpContext.GetTokenAsync("access_token"));

                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}



