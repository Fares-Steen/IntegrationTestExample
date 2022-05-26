using Microsoft.EntityFrameworkCore;

namespace S1.SQL.Persistence.Initialize;

public class DbInitializer : IDbInitializer
{
    private readonly Service1DbContext _context;


    public DbInitializer(Service1DbContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        var a = _context.Database.GetPendingMigrations().Any();
        if (a)
        {
            _context.Database.Migrate();
        }
    }
}