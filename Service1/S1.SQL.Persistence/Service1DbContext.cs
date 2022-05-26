using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using S1.Domain;
using S1.Domain.Entities.Interfaces;
namespace S1.SQL.Persistence;

public class Service1DbContext:DbContext
{
    public Service1DbContext(DbContextOptions<Service1DbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Product>? Products { get; set; }
    
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
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Service1DbContext>
    {
        public Service1DbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/../Service1/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Service1DbContext>();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlite(connectionString);
            return new Service1DbContext(builder.Options);
        }
    }
}