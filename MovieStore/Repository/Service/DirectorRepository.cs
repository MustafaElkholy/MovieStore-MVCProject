using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.GenericRepository;
using MovieStore.Repository.Interface;

namespace MovieStore.Repository.Service
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        private readonly AppDbContext context;

        public DirectorRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Director> GetById(int id) => await context.Directors.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);


       

    }
}
