using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Permissions;

public sealed class Permission : Entity<PermissionId>
{
    public string? Nombre { get; set; }

    private Permission()
    {
    }

    public Permission(PermissionId id, string nombre) : base(id)
    {
        Nombre = nombre;
    }

    public Permission(string nombre) : base()
    {
        Nombre = nombre;
    }

    public static Result<Permission> Create(string nombre)
    {
        return new Permission(nombre);
    }
    
}