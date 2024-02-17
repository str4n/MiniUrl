namespace MiniUrl.Application.Users.Requests;

public sealed record SignUpRequest(Guid Id, string Email, string Username, string Password);