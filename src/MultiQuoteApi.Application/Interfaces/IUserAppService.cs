using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserModel?> GetAsync(int userId, RecordStatusEnum recordStatus);
        Task<int> InsertAsync(int inclusionUserId, UserModel model);
        Task CreateUserAsync(UserPersonModel user);
        Task ValidateUserAsync(string login);
    }
}
