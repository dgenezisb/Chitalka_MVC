using ChitalkaMVC.Logic.Authors;
using ChitalkaMVC.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorManager _manager;
        public AuthorsController(IAuthorManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("authors")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            var item = await _manager.GetAll();
            return View(item);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "CountryId")] Author author)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (ModelState.IsValid)
            {
                await _manager.Create(author);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id == null)
                return NotFound();
            var item = await _manager.Find((int)id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "CountryId")] Author author)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id != author.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                if (await _manager.Update(author))
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            return View(author);
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
            var item = await _manager.Find((int)id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
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
