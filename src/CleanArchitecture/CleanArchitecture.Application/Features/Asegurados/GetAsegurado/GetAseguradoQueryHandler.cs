using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using Dapper;

namespace CleanArchitecture.Application.Features.Asegurados.GetAsegurado;

internal sealed class GetAseguradoQueryHandler
: IQueryHandler<GetAseguradQuery, IReadOnlyList<AseguradoResponse>>
{
    private readonly ICoreDBConnectionFactory _sqlConnectionFactory;
    public GetAseguradoQueryHandler(ICoreDBConnectionFactory sqlconnectionFactory)
    {
        _sqlConnectionFactory = sqlconnectionFactory;
    }
    public async Task<Result<IReadOnlyList<AseguradoResponse>>> Handle(GetAseguradQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        const string sql = """
            select
            a.Id,
            a.codigoParentesco,
            a.numeroContrato
            from Asegurados as a
        """;
        var asegurados = await connection.QueryAsync<AseguradoResponse>(sql);
        return asegurados.ToList();
    }
}