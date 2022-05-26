using Microsoft.EntityFrameworkCore;
using S1.Domain;
using S1.SQL.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests.TestRepositories
{
    public class Service1TestRepository
    {
        private readonly Service1DbContext service1DbContext;
        public Service1TestRepository(Service1DbContext service1DbContext)
        {
            this.service1DbContext = service1DbContext;
        }
        private void DetachAllEntities()
        {
            var changedEntriesCopy = service1DbContext.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        public async Task<Product> InjectProductInDb(Product product)
        {
            await service1DbContext.Set<Product>().AddAsync(product);
            await service1DbContext.SaveChangesAsync();
            DetachAllEntities();
            return product;
        } 
    }
}
