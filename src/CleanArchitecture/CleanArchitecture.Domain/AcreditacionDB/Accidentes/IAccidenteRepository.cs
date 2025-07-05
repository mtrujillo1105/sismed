namespace CleanArchitecture.Domain.AcreditacionDB.Accidentes;

public interface IAccidenteRepository
{
    Task<Accidente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Accidente accidente);
}