using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.Interface;

namespace MovieStore.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository cinemaRepo;

        public CinemaController(ICinemaRepository cinemaRepo)
        {
            this.cinemaRepo = cinemaRepo;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await cinemaRepo.GetAll();
            return View(cinemas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await cinemaRepo.GetById(id);
            if (cinema is null) return View("NotFound");

            return View(cinema);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinemaRepo.Add(cinema);
                return RedirectToAction("Index");

            }
            return View(cinema);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await cinemaRepo.GetById(id);
            if (actor is null) return View("NotFound");
            return View(actor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinemaRepo.Update(cinema, id);

                return RedirectToAction("Index");

            }
            return View(cinema);
        }


        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await cinemaRepo.Delete(id);
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = "Foriegn Key Constraint Errors,\n" + ex.Message;

            }

            return RedirectToAction("Index");

        }
    }
}
