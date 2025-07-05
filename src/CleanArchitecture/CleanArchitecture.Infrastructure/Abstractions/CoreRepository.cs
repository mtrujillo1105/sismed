using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Abstractions;

internal abstract class CoreRepository<T>
where T : Entity
{
    protected readonly CoreDbContext DbContext;
    protected CoreRepository(CoreDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        return await DbContext.Set<T>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
}