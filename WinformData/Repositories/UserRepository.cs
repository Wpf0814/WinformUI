using Microsoft.EntityFrameworkCore;
using WinFormModel;
using WinFormService;

namespace WinFormData
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public UserRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return await dbContext.Users
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return await dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateAsync(UserModel user)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
