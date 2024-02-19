using MiniUrl.Domain.Users.Exceptions;

namespace MiniUrl.Domain.Users.User;

public sealed class User
{
    public Guid Id { get; }
    public Email Email { get; private set; }
    public Username Username { get; private set; }
    public Password Password { get; private set; }
    public UserState State { get; private set; }
    public DateTime CreatedAt { get; }

    public User(Email email, Username username, Password password, DateTime createdAt, Guid id = default)
    {
        Id = id != Guid.Empty ? id : Guid.NewGuid();
        Email = email;
        Username = username;
        Password = password;
        CreatedAt = createdAt;
        State = UserState.Active;
    }

    private User()
    {
    }

    public void Delete()
    {
        if (State is UserState.Deleted)
        {
            throw new UserAlreadyDeletedException();
        }

        State = UserState.Deleted;
    }
}

public enum UserState
{
    Deleted = 0,
    Active = 1,
}