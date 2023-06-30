using MovieStore.Models;
using MovieStore.Repository.GenericRepository;

namespace MovieStore.Repository.Interface
{
    public interface ICinemaRepository : IGenericRepository<Cinema>
    {
       new Task<Cinema> GetById(int id);
    }
}
