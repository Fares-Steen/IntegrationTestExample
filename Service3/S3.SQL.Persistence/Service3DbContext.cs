using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using S3.Domain.Entities;
using S3.Domain.Entities.Interfaces;

namespace S3.SQL.Persistence;

public class Service3DbContext:DbContext
{
    public Service3DbContext(DbContextOptions<Service3DbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<User>? User { get; set; }
    
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        var addedEntities = ChangeTracker.Entries<IEntity>().Where(e => e.State == EntityState.Added).ToList();

        addedEntities.ForEach(e => { e.Entity.DateAdded = DateTime.Now; });

        var editedEntities = ChangeTracker.Entries<IEntity>().Where(E => E.State == EntityState.Modified).ToList();

        editedEntities.ForEach(e =>
        {
            e.Property(x => x.DateAdded).IsModified = false;

            e.Entity.DateUpdated = DateTime.Now;
        });

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Service3DbContext>
    {
        public Service3DbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/../Service3/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Service3DbContext>();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlite(connectionString);
            return new Service3DbContext(builder.Options);
        }
    }
}