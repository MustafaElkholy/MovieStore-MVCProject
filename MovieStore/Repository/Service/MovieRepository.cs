using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.GenericRepository;
using MovieStore.Repository.Interface;
using MovieStore.ViewModels;
using System.IO;

namespace MovieStore.Repository.Service
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly AppDbContext context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public new async Task<Movie> GetById(int id)
        {
            return await context.Movies.Include(x => x.MovieActors).ThenInclude(x => x.Actor)
                .Include(x => x.Director).Include(x => x.MovieGenres).ThenInclude(x => x.Genre).FirstOrDefaultAsync(x => x.Id == id);
        }

        public new async Task<IEnumerable<Movie>> GetAll()
        {
            return await context.Movies.Include(x => x.MovieActors).ThenInclude(x => x.Actor)
                .Include(x => x.Director).Include(x => x.MovieGenres).ThenInclude(x => x.Genre).
                OrderByDescending(m => m.IMDBRating).ToListAsync();

        }

        public async Task<NewMovieDropDownlistItems> GetNewMovieDropDownlistValues()
        {
            var response = new NewMovieDropDownlistItems()
            {
                Actors = await context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Directors = await context.Directors.OrderBy(a => a.FullName).ToListAsync(),
                Generes = await context.Genres.OrderBy(a => a.GenreName).ToListAsync()
            };


            return response;
        }

        public async Task AddNewMovie(MovieViewModel newMovieModel)
        {
            var newMovie = new Movie()
            {
                Name = newMovieModel.Name,
                Description = newMovieModel.Description,
                ImageURL = newMovieModel.ImageURL,
                Price = newMovieModel.Price,
                ReleaseDate = newMovieModel.ReleaseDate,
                DirectorId = newMovieModel.DirectorId,
                IMDBLink = newMovieModel.IMDBLink,
                IMDBRating = newMovieModel.IMDBRating


            };

            await context.AddAsync(newMovie);
            await context.SaveChangesAsync();
            foreach (var actorId in newMovieModel.ActorIds)
            {
                var movie_actor = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };

                await context.ActorsMovies.AddAsync(movie_actor);

            }
            await context.SaveChangesAsync();


            foreach (var genereId in newMovieModel.GenereId)
            {
                var movie_genre = new MovieGenre()
                {
                    MovieId = newMovie.Id,
                    GenreId = genereId
                };

                await context.MovieGenres.AddAsync(movie_genre);

            }
            await context.SaveChangesAsync();

        }

        public async Task UpdateMovie(MovieViewModel newMovieModel)
        {
            var movieFromDB = await context.Movies.FirstOrDefaultAsync(x => x.Id == newMovieModel.Id);
            if (movieFromDB != null)
            {

                movieFromDB.Name = newMovieModel.Name;
                movieFromDB.Description = newMovieModel.Description;
                movieFromDB.ImageURL = newMovieModel.ImageURL;
                movieFromDB.Price = newMovieModel.Price;
                movieFromDB.ReleaseDate = newMovieModel.ReleaseDate;
                movieFromDB.DirectorId = newMovieModel.DirectorId;
                movieFromDB.IMDBLink = newMovieModel.IMDBLink;
                movieFromDB.IMDBRating = newMovieModel.IMDBRating;

                await context.SaveChangesAsync();
            }

            var existingAcorInMovie = context.ActorsMovies.Where(x => x.MovieId == newMovieModel.Id).ToList();
            context.ActorsMovies.RemoveRange(existingAcorInMovie);
            await context.SaveChangesAsync();


            var existingGenresInMovie = context.MovieGenres.Where(x => x.MovieId == newMovieModel.Id).ToList();
            context.MovieGenres.RemoveRange(existingGenresInMovie);
            await context.SaveChangesAsync();




            foreach (var actorId in newMovieModel.ActorIds)
            {
                var movie_actor = new ActorMovie()
                {
                    MovieId = newMovieModel.Id,
                    ActorId = actorId
                };

                await context.ActorsMovies.AddAsync(movie_actor);

            }
            await context.SaveChangesAsync();


            foreach (var genereId in newMovieModel.GenereId)
            {
                var movie_genre = new MovieGenre()
                {
                    MovieId = newMovieModel.Id,
                    GenreId = genereId
                };

                await context.MovieGenres.AddAsync(movie_genre);

            }
            await context.SaveChangesAsync();
        }
    }
}
