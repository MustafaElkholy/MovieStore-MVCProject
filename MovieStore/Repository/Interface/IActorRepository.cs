using MovieStore.Models;
using MovieStore.Repository.GenericRepository;

namespace MovieStore.Repository.Interface
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        Task<Actor> GetById(int id);
    }
}
