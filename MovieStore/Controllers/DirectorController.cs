using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.Interface;

namespace MovieStore.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository directorRepo;
        public DirectorController(IDirectorRepository directorRepo)
        {
            this.directorRepo = directorRepo;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await directorRepo.GetAll();
            return View(allProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var director = await directorRepo.GetById(id);
            if (director is null) return View("NotFound");

            return View(director);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                directorRepo.Add(director);
                return RedirectToAction("Index");

            }
            return View(director);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await directorRepo.GetById(id);
            if (actor is null) return View("NotFound");
            return View(actor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Director director) 
        {
            if (ModelState.IsValid)
            {
                directorRepo.Update(director, id);

                return RedirectToAction("Index");

            }
            return View(director);
        }


        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await directorRepo.Delete(id);
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
