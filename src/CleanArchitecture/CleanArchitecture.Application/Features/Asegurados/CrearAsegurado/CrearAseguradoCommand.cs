
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Features.Asegurados.CrearAsegurado;
public record CrearAseguradoCommand(
    string codigoParentesco,
    string numeroContrato
):ICommand<Guid>;
