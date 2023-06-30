using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.GenericRepository;
using MovieStore.Repository.Interface;

namespace MovieStore.Repository.Service
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        private readonly AppDbContext context;

        public CinemaRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Cinema> GetById(int id)
        {
            return await context.Cinemas.Include(x => x.CinemaMovies).ThenInclude(x => x.Movie).FirstOrDefaultAsync(x => x.Id == id);
        }

        
    }
}
