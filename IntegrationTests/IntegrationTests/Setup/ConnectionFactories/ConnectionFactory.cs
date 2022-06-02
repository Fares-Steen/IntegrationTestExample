using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Setup.ConnectionFactories
{
    public class ConnectionFactory<TDb> where TDb : DbContext
    {
        private readonly SqliteConnection _connection = new("DataSource=:memory:");
        private bool _disposedValue;
        public TDb CreateContextForSqLite(Func<DbContextOptions<TDb>, TDb> createDbContext)
        {
            _connection.Open();

            var option = new DbContextOptionsBuilder<TDb>().UseSqlite(_connection).Options;
            var context = createDbContext(option);

            context!.Database.EnsureDeleted();
            context!.Database.EnsureCreated();

            return context;
        }

        private void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing) _connection.Close();

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
