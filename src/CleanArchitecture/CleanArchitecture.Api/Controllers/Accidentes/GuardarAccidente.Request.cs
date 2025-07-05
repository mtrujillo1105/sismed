namespace CleanArchitecture.Api.Controllers.Accidentes;
public sealed record GuardarAccidenteRequest(
    Guid IdAsegurado,
    string Descripcion,
    string CodIpress
);