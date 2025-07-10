using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.Features.Users.RegisterUser;

internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly ICoreUnitOfWork _unitOfWork;
    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        ICoreUnitOfWork unitOfWork
        )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken
        )
    {
        var userExists = await _userRepository.IsUserExists(request.Email);
        if (userExists)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = User.Create(
            request.Nombre,
            request.Apellidos,
            request.Email,
            passwordHash
        );

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();
        return user.Id!.Value;
    }
}