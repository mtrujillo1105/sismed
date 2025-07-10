using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.AcreditacionDB.Accidentes;
using CleanArchitecture.Domain.CoreDB.Asegurados;
using CleanArchitecture.Infrastructure.Abstractions;
using CleanArchitecture.Infrastructure.DbContexts;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class AccidenteRepository : AcreditacionRepository<Accidente,AccidenteId>, IAccidenteRepository
{
    public AccidenteRepository(
        AcreditacionDbContext dbContext) : base(dbContext)
    {

    }

}