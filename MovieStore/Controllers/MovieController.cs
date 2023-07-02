using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.Interface;
using MovieStore.ViewModels;
using System.Runtime.CompilerServices;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepo;
        public MovieController(IMovieRepository movieRepo)
        {
            this.movieRepo = movieRepo;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await movieRepo.GetAll();

            return View(movies);
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var movies = await movieRepo.GetAll();
            

            if (!string.IsNullOrEmpty(searchString))
            {
               

                var searchResult = movies
                    .Where(movie => movie.Name.ToLower().Contains(searchString.ToLower().Trim())
                     || movie.MovieGenres.Select(x => x.Genre.GenreName.ToLower()).Contains(searchString.ToLower().Trim())).ToList();


                return View("Index", searchResult);
            }

            return View("Index",movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await movieRepo.GetById(id);
            if (movie is null) { return View("NotFound"); }

            return View(movie);


        }

        public async Task<IActionResult> Create()
        {
            var movieDropDownlistItems = await movieRepo.GetNewMovieDropDownlistValues();

            ViewBag.Actors = new SelectList(movieDropDownlistItems.Actors, "Id", "FullName");
            ViewBag.Directors = new SelectList(movieDropDownlistItems.Directors, "Id", "FullName");
            ViewBag.Generes = new SelectList(movieDropDownlistItems.Generes, "Id", "GenreName");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel movieModel)
        {
            if (ModelState.IsValid)
            {

                await movieRepo.AddNewMovie(movieModel);
                return RedirectToAction("Index");

            }
            return View(movieModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await movieRepo.GetById(id);
            if (movie is null) return View("NotFound");

            var response = new MovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                DirectorId = movie.DirectorId,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                IMDBRating = movie.IMDBRating,
                IMDBLink = movie.IMDBLink,
                ActorIds = movie.MovieActors.Select(x => x.ActorId).ToList(),
                GenereId = movie.MovieGenres.Select(x => x.GenreId).ToList(),

            };

            var movieDropDownlistItems = await movieRepo.GetNewMovieDropDownlistValues();

            ViewBag.Actors = new SelectList(movieDropDownlistItems.Actors, "Id", "FullName");
            ViewBag.Directors = new SelectList(movieDropDownlistItems.Directors, "Id", "FullName");
            ViewBag.Generes = new SelectList(movieDropDownlistItems.Generes, "Id", "GenreName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieViewModel movieModel)
        {
            if (id != movieModel.Id) return View("NotFound");

            if (ModelState.IsValid)
            {

                await movieRepo.UpdateMovie(movieModel);
                return RedirectToAction("Index");

            }
            return View(movieModel);
        }


    }
}
