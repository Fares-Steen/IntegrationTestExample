using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using S2.Domain;
using S2.Domain.Entities;
using S2.Domain.Entities.Interfaces;
namespace S2.SQL.Persistence;

public class Service2DbContext:DbContext
{
    public Service2DbContext(DbContextOptions<Service2DbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<ProductDetails>? ProductDetails { get; set; }
    
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
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Service2DbContext>
    {
        public Service2DbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/../Service2/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Service2DbContext>();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlite(connectionString);
            return new Service2DbContext(builder.Options);
        }
    }
}