using MovieStore.Models;
using MovieStore.Repository.GenericRepository;
using MovieStore.ViewModels;

namespace MovieStore.Repository.Interface
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        new Task<Movie> GetById(int id);
        new Task<IEnumerable<Movie>> GetAll();
        Task<NewMovieDropDownlistItems> GetNewMovieDropDownlistValues();

        Task AddNewMovie(MovieViewModel newMovie);
        Task UpdateMovie(MovieViewModel newMovie);



    }
}
