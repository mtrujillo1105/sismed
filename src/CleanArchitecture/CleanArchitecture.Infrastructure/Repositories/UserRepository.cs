using CleanArchitecture.Domain.Users;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;

namespace CleanArchitecture.Infrastructure.Repositories;
internal sealed class UserRepository : CoreRepository<User>, IUserRepository
{
    public UserRepository(CoreDbContext dbContext) : base(dbContext) 
    {
        
    }
}