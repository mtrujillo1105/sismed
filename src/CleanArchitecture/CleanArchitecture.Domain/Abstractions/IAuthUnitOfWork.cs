namespace CleanArchitecture.Domain.Abstractions;

public interface IAuthUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
