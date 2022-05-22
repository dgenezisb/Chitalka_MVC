using ChitalkaMVC.Logic.UserBooks;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class UserBooksController : Controller
    {
        private readonly IUserBookManager _manager;
        public UserBooksController(IUserBookManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
                return NotFound();
            var username = HttpContext.Session.GetString("_Username");
            if (username == null)
                return BadRequest();
            await _manager.Create(username, (int)id);
            return RedirectToAction("Details", "Books", new { id });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var username = HttpContext.Session.GetString("_Username");
            if (username == null)
                return BadRequest();
            await _manager.Delete(username, (int)id);
            return RedirectToAction("Details", "Books", new { id });
        }
    }
}
