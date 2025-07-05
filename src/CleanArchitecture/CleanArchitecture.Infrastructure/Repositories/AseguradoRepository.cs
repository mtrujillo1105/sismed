using CleanArchitecture.Domain.CoreDB.Asegurados;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class AseguradoRepository : CoreRepository<Asegurado>, IAseguradoRepository
{
    public AseguradoRepository(CoreDbContext dbContext) : base(dbContext)
    {

    }

    public override void Add(Asegurado entity)
    {
        base.Add(entity);
    }
    
}