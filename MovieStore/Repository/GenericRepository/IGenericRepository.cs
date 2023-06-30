using MovieStore.Models;

namespace MovieStore.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity, int id);
        Task Delete(int id);
   

    }
}
