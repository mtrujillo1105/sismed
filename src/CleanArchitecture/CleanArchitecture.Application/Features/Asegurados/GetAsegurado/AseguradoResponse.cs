namespace CleanArchitecture.Application.Features.Asegurados.GetAsegurado;

public sealed class AseguradoResponse
{
    public Guid Id { get; init; }
    public string? codigoParentesco { get; init; }
    public string? numeroContrato { get; init; }
}