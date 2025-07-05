using System.Data;

namespace CleanArchitecture.Application.Abstractions.Data;

public interface ICoreDBConnectionFactory
{
    IDbConnection CreateConnection();
}