namespace CleanArchitecture.Application.Features.Users.LoginUser;
public record LoginUserRequest(
    string Email,
    string Password
);