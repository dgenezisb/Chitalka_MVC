using ChitalkaMVC.Logic.Notes;
using ChitalkaMVC.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteManager _manager;
        public NotesController(INoteManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var item = await _manager.Find((int)id);
            if (item == null)
                return NotFound();
            if ((HttpContext.Session.GetString("_Username") != item.Username) && (HttpContext.Session.GetInt32("_IsAdmin") != 1))
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Title", "Text", "Username")] Note note)
        {
            if (id != note.Id)
                return NotFound();
            if ((HttpContext.Session.GetString("_Username") != note.Username) && (HttpContext.Session.GetInt32("_IsAdmin") != 1))
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            if (ModelState.IsValid)
            {
                if (await _manager.Update(note))
                    return RedirectToAction(nameof(UsersController.Profile), "Users");
                else
                    return NotFound();
            }
            return View(note);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
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
            if ((HttpContext.Session.GetString("_Username") != item.Username) && (HttpContext.Session.GetInt32("_IsAdmin") != 1))
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _manager.Delete(id);
            return RedirectToAction(nameof(UsersController.Profile), "Users");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var username = HttpContext.Session.GetString("_Username");
            if (username == null)
                return RedirectToAction(nameof(HomeController.Forbidden), "Home");
            return View(new Note { Username = username });
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title", "Text", "Username")] Note note)
        {
            if (ModelState.IsValid)
            {
                var username = HttpContext.Session.GetString("_Username");
                if (username != note.Username)
                    return RedirectToAction(nameof(HomeController.Forbidden), "Home");
                await _manager.Create(note);
                return RedirectToAction(nameof(UsersController.Profile), "Users");
            }
            return RedirectToAction(nameof(UsersController.Profile), "Users");
        }
    }
}
