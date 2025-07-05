using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Features.Accidentes.GenerarAccidente;
public record GenerarAccidenteCommand(
    Guid IdAsegurado,
    string Descripcion,
    string CodIpress
):ICommand<Guid>;
