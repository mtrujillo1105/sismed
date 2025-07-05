using System.Data;
using CleanArchitecture.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Data;

public class CoreDBConnectionFactory : ICoreDBConnectionFactory
{
    private readonly string _connectionString;
    public CoreDBConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("CoreConnectionString") ??
            throw new InvalidOperationException("Connection string 'Database' not found.");
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
