using Microsoft.Extensions.DependencyInjection;
using S2.SQL.Persistence;
using Microsoft.EntityFrameworkCore;
using S2.Application.IRepositories;
using S2.SQL.Persistence.Initialize;
using S2.SQL.Persistence.Repositories;

namespace S2.PersistenceDI;

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