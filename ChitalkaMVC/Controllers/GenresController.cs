using ChitalkaMVC.Logic.Genres;
using ChitalkaMVC.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreManager _manager;
        public GenresController(IGenreManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("genres")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            var genres = await _manager.GetAll();
            return View(genres);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id == null)
                return NotFound();
            var genre = await _manager.Find((int)id);
            if (genre == null)
                return NotFound();
            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id","Name")] Genre genre)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id != genre.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                if (await _manager.Update(genre))
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            return View(genre);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Genre genre)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (ModelState.IsValid)
            {
                await _manager.Create(genre.Name);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id == null)
            {
                return NotFound();
            }
            var genre = await _manager.Find((int)id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            await _manager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
