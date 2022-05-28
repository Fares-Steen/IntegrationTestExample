using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using S1.SQL.Persistence;

namespace IntegrationTests.Setup.ConnectionFactories
{
    public sealed class Service1ConnectionFactory
    {
        private readonly SqliteConnection connection = new("DataSource=:memory:");
        private bool disposedValue;

        public Service1DbContext CreateContextForSqLite()
        {
            connection.Open();

            var option = new DbContextOptionsBuilder<Service1DbContext>().UseSqlite(connection).Options;

            var context = new Service1DbContext(option);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

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
