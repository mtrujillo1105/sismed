using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Vehiculos;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class AlquilerRepository : CoreRepository<Alquiler>, IAlquilerRepository
{
    public AlquilerRepository(CoreDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsOverlappingAsync(
        Vehiculo vehiculo,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Alquiler>().AnyAsync(
            alquiler => 
                alquiler.VehiculoId == vehiculo.Id,
                cancellationToken
        );
    }
}