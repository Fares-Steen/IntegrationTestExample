

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using S3.SQL.Persistence;

namespace IntegrationTests
{
    public sealed class Service3ConnectionFactory
    {
        private readonly SqliteConnection connection = new("DataSource=:memory:");
        private bool disposedValue;

        public Service3DbContext CreateContextForSqLite()
        {
            connection.Open();

            var option = new DbContextOptionsBuilder<Service3DbContext>().UseSqlite(connection).Options;

            var context = new Service3DbContext(option);

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
