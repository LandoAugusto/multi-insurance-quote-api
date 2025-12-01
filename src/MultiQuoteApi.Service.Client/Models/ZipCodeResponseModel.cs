using Newtonsoft.Json;

namespace MultiQuoteApi.Service.Client.Models
{
    public class ZipCodeResponseModel
    {
        [JsonProperty("cep")]
        public string? ZipCode { get; set; }

        [JsonProperty("logradouro")]
        public string? StreetName { get; set; }

        [JsonProperty("complemento")]
        public string? Complement { get; set; }

        [JsonProperty("bairro")]
        public string? District { get; set; }

        [JsonProperty("estado")]
        public string State { get; set; }

        [JsonProperty("uf")]
        public string StateUf { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }
    }
}

