using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;

namespace MovieStore.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDbContext context;
        public ProducerController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await context.Producers.ToListAsync();
            return View(producers);
        }
    }
}
