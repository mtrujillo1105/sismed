using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Features.Accidentes.GetAccidente;

public sealed record GetAccidenteQuery(
    //Guid idAccidente
):IQuery<IReadOnlyList<AccidenteResponse>>;
