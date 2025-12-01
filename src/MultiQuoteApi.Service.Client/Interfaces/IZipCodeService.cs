using MultiQuoteApi.Service.Client.Models;

namespace MultiQuoteApi.Service.Client.Interfaces
{
    public interface IZipCodeService
    {
        Task<ZipCodeModel> GetAsync(string zipcode);
    }
}
