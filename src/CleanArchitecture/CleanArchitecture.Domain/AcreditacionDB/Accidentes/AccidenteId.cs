namespace CleanArchitecture.Domain.AcreditacionDB.Accidentes;

public record AccidenteId(Guid Value)
{
    public static AccidenteId New() => new(Guid.NewGuid());
}