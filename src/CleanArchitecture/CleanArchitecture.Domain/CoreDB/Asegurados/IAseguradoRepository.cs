namespace CleanArchitecture.Domain.CoreDB.Asegurados;

public interface IAseguradoRepository
{
    Task<Asegurado?> GetByIdAsync(
        AseguradoId id,
        CancellationToken cancellationToken = default
    );

    void Add(Asegurado asegurado);
}