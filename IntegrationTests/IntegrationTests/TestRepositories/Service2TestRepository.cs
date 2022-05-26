using Microsoft.EntityFrameworkCore;
using S2.Domain.Entities;
using S2.SQL.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests.TestRepositories
{
    internal class Service2TestRepository
    {
        private readonly Service2DbContext service2DbContext;
        public Service2TestRepository(Service2DbContext service2DbContext)
        {
            this.service2DbContext = service2DbContext;
        }
        private void DetachAllEntities()
        {
            var changedEntriesCopy = service2DbContext.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        public async Task<ProductDetails> InjectProductDetailsInDb(ProductDetails productDetails)
        {
            await service2DbContext.Set<ProductDetails>().AddAsync(productDetails);
            await service2DbContext.SaveChangesAsync();
            DetachAllEntities();
            return productDetails;
        } 
    }
}
