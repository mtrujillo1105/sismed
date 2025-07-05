namespace CleanArchitecture.Application.Features.Accidentes.GetAccidente;

public sealed class AccidenteResponse
{
    public Guid Id { get; init; }

    public string? Descripcion { get; init; }
    public string? CodIpress { get; init; }

     public Guid IdAfiliado { get; init; }
}