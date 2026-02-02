using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DbContexts;

public sealed class AuthDbContext : DbContext, IAuthUnitOfWork
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {

    }
}