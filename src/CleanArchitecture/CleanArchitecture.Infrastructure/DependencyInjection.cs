using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.AcreditacionDB.Accidentes;
using CleanArchitecture.Domain.CoreDB.Asegurados;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.DbContexts;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {

        // EF Core si lo usas
        var coreConnectionString = configuration.GetConnectionString("CoreConnectionString")??throw new ArgumentNullException(nameof(configuration));
        var acreditacionConnectionString = configuration.GetConnectionString("AcreditacionConnectionString")?? throw new ArgumentNullException(nameof(configuration), "AcreditacionConnectionString is not configured.");
        services.AddDbContext<CoreDbContext>(options =>
        {
            options.UseSqlServer(coreConnectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName);
            });
        });
        services.AddScoped<ICoreUnitOfWork>(sp => sp.GetRequiredService<CoreDbContext>());

        services.AddDbContext<AcreditacionDbContext>(options =>
        {
            options.UseSqlServer(acreditacionConnectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(AcreditacionDbContext).Assembly.FullName);
            });
        });
        services.AddScoped<IAcreditacionUnitOfWork>(sp => sp.GetRequiredService<AcreditacionDbContext>());

        // Aca Dapper
        services.AddScoped<ICoreDBConnectionFactory, CoreDBConnectionFactory>();
        services.AddScoped<IAcreditacionDBConnectionFactory, AcreditacionDBConnectionFactory>();

        // Agrego servicios
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAseguradoRepository, AseguradoRepository>();
        services.AddScoped<IAccidenteRepository, AccidenteRepository>();

        return services;
    }
}