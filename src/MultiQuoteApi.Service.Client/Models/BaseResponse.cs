using Newtonsoft.Json;

namespace MultiQuoteApi.Service.Client.Models
{
    public abstract class BaseResponse
    {
        [JsonProperty("cd_retorno")]
        public int? cd_retorno { get; set; }

        [JsonProperty("nm_retorno")]
        public string? nm_retorno { get; set; }
    }
}
