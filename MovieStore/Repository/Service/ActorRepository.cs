using Microsoft.EntityFrameworkCore;
using MovieStore.Data.DataBase;
using MovieStore.Models;
using MovieStore.Repository.GenericRepository;
using MovieStore.Repository.Interface;

namespace MovieStore.Repository.Service
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        private readonly AppDbContext context;

        public ActorRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Actor> GetById(int id)
        {
           return await context.Actors.Include(x => x.ActorMovies).ThenInclude(x=>x.Movie).FirstOrDefaultAsync(x=>x.Id == id);
        }

     
        
    }
}
