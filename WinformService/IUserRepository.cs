

using WinFormModel;

namespace WinFormService
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();

        Task<UserModel?> GetByIdAsync(int id);

        Task<UserModel> AddAsync(UserModel user);

        Task<UserModel> UpdateAsync(UserModel user);
    }
}
