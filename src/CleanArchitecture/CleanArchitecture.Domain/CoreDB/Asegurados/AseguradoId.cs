namespace CleanArchitecture.Domain.CoreDB.Asegurados;

public record AseguradoId(Guid Value)
{
    public static AseguradoId New() => new(Guid.NewGuid());
}