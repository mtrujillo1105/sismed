using CleanArchitecture.Domain.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infrastructure.Authentication;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission {get;}    
}