namespace MiniUrl.Application.Users.Services;

internal interface IPasswordManager
{
    public string Secure(string password);
    public bool Validate(string password, string securedPassword);
}