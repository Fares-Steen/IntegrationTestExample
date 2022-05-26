using Microsoft.Extensions.DependencyInjection;
using S3.SQL.Persistence;
using Microsoft.EntityFrameworkCore;
using S3.Application.IRepositories;
using S3.SQL.Persistence.Initialize;
using S3.SQL.Persistence.Repositories;

namespace S3.PersistenceDI;

public static class PersistenceDI
{
    public static IServiceCollection AddPersistenceLibrary(this IServiceCollection services)
    {
        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
    public static IServiceCollection AddPersistenceDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<Service2DbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        return services;
    }
}