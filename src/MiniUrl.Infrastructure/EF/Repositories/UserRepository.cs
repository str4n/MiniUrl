using Microsoft.EntityFrameworkCore;
using MiniUrl.Domain.Users.Repositories;
using MiniUrl.Domain.Users.User;

namespace MiniUrl.Infrastructure.EF.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly MiniUrlDbContext _dbContext;

    public UserRepository(MiniUrlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> AnyAsync(Email email)
        => _dbContext.Users.AnyAsync(x => x.Email == email);

    public Task<bool> AnyAsync(Username username)
        => _dbContext.Users.AnyAsync(x => x.Username == username.Value.ToLowerInvariant());

    public Task<User> GetAsync(Username username)
        => _dbContext.Users.SingleOrDefaultAsync(x => x.Username == username.Value.ToLowerInvariant());
}