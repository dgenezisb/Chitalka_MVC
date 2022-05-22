using ChitalkaMVC.Logic.Books;
using ChitalkaMVC.Models;
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
        public async Task<IActionResult> List()
        {
            var books = await _manager.GetAll();
            return View(new BooksListViewModel { Books = books });
        }
        [HttpPost]
        public async Task<IActionResult> List(BookFilterOptions options)
        {
            
            var books = await _manager.GetAll();
            books = books.Where(book => BookFilter.Filter(options, book)).ToList();
            return View(new BooksListViewModel { Options = options, Books = books });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
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

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel model)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            await _manager.SetGenresById(model.Book, model.GenreIds);

            if (ModelState.ErrorCount == 1) 
            {
                await _manager.Create(model.Book, model.Image);
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
            return View(new BookViewModel { Book = item });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookViewModel model)
        {
            if (HttpContext.Session.GetInt32("_IsAdmin") != 1)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (id != model.Book.Id)
                return NotFound();
            if (ModelState.ErrorCount == 1)
            {
                await _manager.SetGenresById(model.Book, model.GenreIds);
                if (await _manager.Update(model.Book, model.Image))
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            return View(model);
        }
    }
}
