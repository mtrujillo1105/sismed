using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Abstractions;

internal abstract class CoreRepository<TEntity, TEntityId>
where TEntity : Entity<TEntityId>
where TEntityId: class
{
    protected readonly CoreDbContext DbContext;
    protected CoreRepository(CoreDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<TEntity?> GetByIdAsync(
        TEntityId id,
        CancellationToken cancellationToken = default
    )
    {
        return await DbContext.Set<TEntity>()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
    public virtual void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }
}