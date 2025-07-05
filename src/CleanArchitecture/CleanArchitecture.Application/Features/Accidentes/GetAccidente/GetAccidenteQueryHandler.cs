using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using Dapper;

namespace CleanArchitecture.Application.Features.Accidentes.GetAccidente;

internal sealed class GetAccidenteQueryHandler
: IQueryHandler<GetAccidenteQuery, IReadOnlyList<AccidenteResponse>>
{
    private readonly IAcreditacionDBConnectionFactory _sqlConnectionFactory;
    public GetAccidenteQueryHandler(IAcreditacionDBConnectionFactory sqlconnectionFactory)
    {
        _sqlConnectionFactory = sqlconnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AccidenteResponse>>> Handle(GetAccidenteQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        const string sql = """
            select
                a.Id,
                a.IdAsegurado,
                a.Descripcion,
                a.CodIpress
            from Accidentes as a
        """;
        var accidentes = await connection.QueryAsync<AccidenteResponse>(sql);
        return accidentes.ToList();
    }
}   
