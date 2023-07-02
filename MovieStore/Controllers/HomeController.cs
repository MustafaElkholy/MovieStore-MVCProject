using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.Interface;
using System.Diagnostics;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository movieRepo;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepo, AppDbContext context)
        {
            _logger = logger;
            this.movieRepo = movieRepo;
            this.context = context;
        }


        public async Task<IActionResult> Index()
        {
            var movies = await context.Movies.Include(x=>x.MovieGenres).
                ThenInclude(x=>x.Genre).OrderByDescending(x=>x.IMDBRating).Take(4).ToListAsync();

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}