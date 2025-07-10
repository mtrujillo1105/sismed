using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Roles;

namespace CleanArchitecture.Domain.Users;

public sealed class User : Entity<UserId>
{
    public string? Nombre { get; private set; }
    public string? Apellido { get; private set; }
    public string? Email { get; private set; }
    public string? PasswordHash { get; private set; }

    private User()
    {

    }
    private User(
        UserId id,
        string nombre,
        string apellido,
        string email,
        string passwordHash
        ) : base(id)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static User Create(
        string nombre,
        string apellido,
        string email,
        string passwordHash
    )
    {
        var user = new User(UserId.New(), nombre, apellido, email, passwordHash);
        //user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));//publisher
        return user;
    }
    
    public ICollection<Role>? Roles {get; set;}
}