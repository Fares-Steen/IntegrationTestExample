using Microsoft.EntityFrameworkCore;
using S3.Domain.Entities;
using S3.SQL.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests.TestRepositories
{
    internal class Service3TestRepository
    {
        private readonly Service3DbContext service3DbContext;
        public Service3TestRepository(Service3DbContext service3DbContext)
        {
            this.service3DbContext = service3DbContext;
        }
        private void DetachAllEntities()
        {
            var changedEntriesCopy = service3DbContext.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        public async Task<User> InjectUserInDb(User user)
        {
            await service3DbContext.Set<User>().AddAsync(user);
            await service3DbContext.SaveChangesAsync();
            DetachAllEntities();
            return user;
        } 
    }
}
