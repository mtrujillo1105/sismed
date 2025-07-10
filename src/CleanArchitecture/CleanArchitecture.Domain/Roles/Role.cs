
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Roles;

public sealed class Role 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string>? Permissions { get; set; }

    private Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Role Cliente => new Role (1, "Cliente");
    public static Role Admin => new Role (2, "Admin");

}