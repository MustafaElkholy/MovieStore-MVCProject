using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using MovieStore.Repository.Interface;
using System.Diagnostics;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository movieRepo;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepo)
        {
            _logger = logger;
            this.movieRepo = movieRepo;
        }


        public async Task<IActionResult> Index()
        {
            var movies = await movieRepo.GetAll();

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