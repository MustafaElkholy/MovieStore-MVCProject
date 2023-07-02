using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Repository.Interface;
using NuGet.Protocol.Core.Types;

namespace MovieStore.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository actorRepo;

        public ActorController(IActorRepository actorRepo)
        {
            this.actorRepo = actorRepo;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await actorRepo.GetAll();
            return View(actors);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]

        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                actorRepo.Add(actor);
                
                return RedirectToAction("Index");

            }
            return View(actor);
        }

        public async Task<IActionResult> Details(int id)
        {
            var actor = await actorRepo.GetById(id);
            if (actor is null) return View("NotFound");

            return View(actor);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await actorRepo.GetById(id);
            if (actor is null) return View("NotFound");
            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Actor actor)
        {
            if (ModelState.IsValid)
            {
                actorRepo.Update(actor, id);

                return RedirectToAction("Index");

            }
            return View(actor);
        }

     
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
               await actorRepo.Delete(id);
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
