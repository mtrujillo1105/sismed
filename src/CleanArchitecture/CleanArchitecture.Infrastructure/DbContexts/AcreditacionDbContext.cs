using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DbContexts;

public sealed class AcreditacionDbContext : DbContext, IAcreditacionUnitOfWork
{
    public AcreditacionDbContext(DbContextOptions<AcreditacionDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcreditacionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("La excepcion por concurrncia se disparo", ex);
        }
    }
}