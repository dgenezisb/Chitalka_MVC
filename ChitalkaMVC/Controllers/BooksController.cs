using ChitalkaMVC.Logic.Books;
using ChitalkaMVC.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookManager _manager;
        public BooksController(IBookManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            var books = await _manager.GetAll();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Description", "Text", "Visibility", 
            "AuthorId", "CenturyId", "Genres")] Book book, int[] genreId)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            await _manager.SetGenresById(book, genreId);

            if (ModelState.ErrorCount == 1) 
            {
                await _manager.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

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
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Description", "Text", "Visibility",
            "AuthorId", "CenturyId", "Genres")] Book book, int[] genreId)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id != book.Id)
                return NotFound();
            if (ModelState.ErrorCount == 1)
            {
                await _manager.SetGenresById(book, genreId);
                if (await _manager.Update(book))
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            return View(book);
        }
    }
}
