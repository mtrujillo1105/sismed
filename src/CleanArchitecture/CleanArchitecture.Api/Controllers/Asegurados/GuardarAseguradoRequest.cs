namespace CleanArchitecture.Api.Controllers.Asegurados;
public sealed record GuardarAseguradoRequest(
    string codigoParentesco,
    string numeroContrato
);