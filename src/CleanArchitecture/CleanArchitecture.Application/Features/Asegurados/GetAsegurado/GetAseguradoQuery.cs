using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Features.Asegurados.GetAsegurado;
public sealed record GetAseguradQuery(
    //Guid idAsegurado
):IQuery<IReadOnlyList<AseguradoResponse>>;