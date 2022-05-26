using Microsoft.Extensions.DependencyInjection;
using S1.SQL.Persistence;
using Microsoft.EntityFrameworkCore;
using S1.Application.IRepositories;
using S1.SQL.Persistence.Initialize;
using S1.SQL.Persistence.Repositories;

namespace S1.PersistenceDI;

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
        services.AddDbContext<Service1DbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        return services;
    }
}