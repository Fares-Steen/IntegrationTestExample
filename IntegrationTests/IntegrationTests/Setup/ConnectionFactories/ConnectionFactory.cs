using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Setup.ConnectionFactories
{
    public class ConnectionFactory<TDB> where TDB : DbContext
    {
        private readonly SqliteConnection connection = new("DataSource=:memory:");
        private bool disposedValue;
        public TDB CreateContextForSqLite(Func<DbContextOptions<TDB>, TDB> createDbContext)
        {
            connection.Open();

            var option = new DbContextOptionsBuilder<TDB>().UseSqlite(connection).Options;
            var context = createDbContext(option);

            context!.Database.EnsureDeleted();
            context!.Database.EnsureCreated();

            return context;
        }

        private void Dispose(bool disposing)
        {
            if (disposedValue) return;
            if (disposing) connection.Close();

            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
