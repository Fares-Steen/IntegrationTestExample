using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace S3.SQL.Persistence.Initialize;

public class DbInitializer : IDbInitializer
{
    private readonly Service2DbContext _context;


    public DbInitializer(Service2DbContext context)
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