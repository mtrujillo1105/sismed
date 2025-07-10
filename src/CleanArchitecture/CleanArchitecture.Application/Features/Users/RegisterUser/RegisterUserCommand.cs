using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Features.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string Email,
    string Nombre,
    string Apellidos,
    string Password
): ICommand<Guid>;
