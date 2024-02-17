using MiniUrl.Domain.Users.User;

namespace MiniUrl.Domain.Users.Repositories;

public interface IUserRepository
{
    public Task AddAsync(User.User user);
    public Task<bool> AnyAsync(Email email);
    public Task<bool> AnyAsync(Username username);
    public Task<User.User> GetAsync(Guid id);
}