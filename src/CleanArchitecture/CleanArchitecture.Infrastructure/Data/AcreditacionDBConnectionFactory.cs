using System.Data;
using CleanArchitecture.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Data;

public class AcreditacionDBConnectionFactory : IAcreditacionDBConnectionFactory
{
    private readonly string _connectionString;
    public AcreditacionDBConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AcreditacionConnectionString") ??
            throw new InvalidOperationException("Connection string 'Database' not found.");
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}