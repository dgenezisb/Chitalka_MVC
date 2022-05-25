using ChitalkaMVC.Logic.Authors;
using ChitalkaMVC.Models;
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
        public async Task<IActionResult> List(int? countryId)
        {
            var authors = await _manager.GetAll();
            if (countryId != null)
                authors = authors.Where(a => a.CountryId == countryId).ToList();
            return View(new AuthorListViewModel { Options = new AuthorFilterOptions(), Authors = authors });
        }
        [HttpPost]
        public async Task<IActionResult> List(AuthorFilterOptions options)
        {

            var authors = await _manager.GetAll();
            authors = authors.Where(author => AuthorFilter.Filter(options, author)).ToList();
            return View(new AuthorListViewModel { Options = options, Authors = authors });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _manager.GetFull((int)id);
            if (item == null)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> Create(AuthorViewModel model)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            await _manager.Create(model.Author, model.Image);
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
            return View(new AuthorViewModel { Author = item });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuthorViewModel model)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id != model.Author.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                if (await _manager.Update(model.Author, model.Image))
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            return View(model);
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
