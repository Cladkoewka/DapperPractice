using DapperPractice.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DapperPractice.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IDbConnectionFactory>(_ => 
            new NpgsqlConnectionFactory(DbConstants.DefaultConnectionStringPath));
        services.AddScoped<ProductRepository>();

        return services;
    }
}