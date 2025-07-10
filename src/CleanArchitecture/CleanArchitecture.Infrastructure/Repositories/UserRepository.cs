using CleanArchitecture.Domain.Users;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;
internal sealed class UserRepository : CoreRepository<User, UserId>, IUserRepository
{
    public UserRepository(CoreDbContext dbContext) : base(dbContext) 
    {
        
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>()
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> IsUserExists(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>()
            .AnyAsync(x => x.Email == email);
    }
}