using CleanArchitecture.Domain.Vehiculos;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;

namespace CleanArchitecture.Infrastructure.Repositories;


internal sealed class VehiculoRepository : CoreRepository<Vehiculo>, IVehiculoRepository
{
    public VehiculoRepository(CoreDbContext dbContext) : base(dbContext)
    {
    }
}
