using WinFormModel;

namespace WinFormService
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserModel>> GetInitialUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            if (users.Count > 0)
            {
                return users;
            }

            foreach (var user in CreateDefaultUsers())
            {
                await _userRepository.AddAsync(user);
            }

            return await _userRepository.GetAllAsync();
        }

        public Task<UserModel> CreateNextUserAsync(string userNamePrefix)
        {
            var user = new UserModel
            {
                UserName = userNamePrefix,
                Age = 20
            };

            return Task.FromResult(user);
        }

        public async Task<UserModel> AddUserAsync(string userNamePrefix)
        {
            var newUser = await CreateNextUserAsync(userNamePrefix);
            var savedUser = await _userRepository.AddAsync(newUser);
            savedUser.UserName = $"{userNamePrefix}_{savedUser.Id}";
            return await _userRepository.UpdateAsync(savedUser);
        }

        private static IEnumerable<UserModel> CreateDefaultUsers()
        {
            yield return new UserModel { UserName = "张三", Age = 20 };
            yield return new UserModel { UserName = "李四", Age = 20 };
            yield return new UserModel { UserName = "王五", Age = 20 };
        }
    }
}
