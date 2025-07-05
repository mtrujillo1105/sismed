using System.Data;

namespace CleanArchitecture.Application.Abstractions.Data;

public interface IAcreditacionDBConnectionFactory
{
    IDbConnection CreateConnection();
}
