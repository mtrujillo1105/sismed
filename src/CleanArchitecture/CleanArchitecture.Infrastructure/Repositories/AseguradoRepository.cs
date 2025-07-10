using CleanArchitecture.Domain.CoreDB.Asegurados;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class AseguradoRepository : CoreRepository<Asegurado, AseguradoId>, IAseguradoRepository
{
    public AseguradoRepository(CoreDbContext dbContext) : base(dbContext)
    {

    }

}