using MovieStore.Models;
using MovieStore.Repository.GenericRepository;

namespace MovieStore.Repository.Interface
{
    public interface IDirectorRepository :IGenericRepository<Director>
    {
        Task<Director> GetById(int id);
    }
}
