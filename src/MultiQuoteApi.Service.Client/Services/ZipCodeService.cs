
using MultiQuoteApi.Core.Infrastructure.Configuration;
using MultiQuoteApi.Core.Infrastructure.Exceptions;
using MultiQuoteApi.Core.Infrastructure.Http;
using MultiQuoteApi.Service.Client.Interfaces;
using MultiQuoteApi.Service.Client.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Component.Log.Interfaces;

namespace MultiQuoteApi.Service.Client.Services
{

    internal class ZipCodeService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option) : IZipCodeService
    {

        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("ZipCode"));

        public async Task<ZipCodeModel> GetAsync(string zipcode)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();

            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));
                rawRequest.RequestUri = $"{_endpont.Url}/ws/{zipcode}/json/";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<ZipCodeResponseModel>(rawResponse.Conteudo);

                return new ZipCodeModel()
                {
                    ZipCode = response.ZipCode,
                    State = response.State,
                    StateUf = response.StateUf,
                    District = response.District,
                    Complement = response.Complement,
                    City = response.City,
                    StreetName = response.StreetName
                };
            }
            catch (Exception exception)
            {
                _logWriter.Error(message: exception.Message);

                if (exception is BusinessException ex)
                {
                    throw ex;
                }

                throw new ServiceUnavailableException($"Erro na chamada do serviço '{rawRequest.RequestUri}': {exception.Message}", exception);
            }
        }
    }
}

