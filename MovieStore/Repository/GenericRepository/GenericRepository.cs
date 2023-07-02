using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieStore.Data.DataBase;

namespace MovieStore.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);

            entityEntry.State = EntityState.Deleted;

            await Save();

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

     

        public async Task Update(T entity, int id)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);

            entityEntry.State = EntityState.Modified;

            await Save();
        }
        private async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
