using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using CleanArchitecture.Application.Abstractions.Authentication;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Users;
using Dapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    private readonly ICoreDBConnectionFactory _sqlConnectionFactory;

    public JwtProvider(
            IOptions<JwtOptions> options,
            ICoreDBConnectionFactory sqlConnectionFactory
        )
    {
        _options = options.Value;
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<string> Generate(User user)
    {

        const string sql = """
                select
                    p.Nombre
                from users usr
                left join UserRoles usrl ON usr.Id = usrl.UserId
                left join RolePermissions rp ON usrl.RoleId = rp.RoleId
                left join Permissions p ON p.Id = rp.PermissionId
                where usr.id=@UserId
        """;        

        using var connection = _sqlConnectionFactory.CreateConnection();

        var permissions = await connection.QueryAsync<string>(sql, new { UserId = user.Id!.Value });

        var permissionCollection = permissions.ToHashSet();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id!.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? throw new ArgumentNullException("user.Email"))
        };

        if (permissionCollection.Count > 0) {
            foreach (var permission in permissionCollection)
            {
                claims.Add(new(CustomClaims.Permissions, permission));
            }
        }

        var sigingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey!)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddDays(365),
            sigingCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}