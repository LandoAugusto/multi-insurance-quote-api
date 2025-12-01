using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public  interface IMenuScreenAppService
    {
        Task<MenuScreenModel?> GetAsync(int code);
    }
}
