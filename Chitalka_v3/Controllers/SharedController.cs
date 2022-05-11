using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chitalka_v3.Data;
using Chitalka_v3.Models;

namespace Chitalka_v3.Controllers
{
    public class SharedController : Controller
    {
        private readonly Chitalka_v3Context _context;

        public SharedController(Chitalka_v3Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> _Layout()
        {
            var booksList = _context.Books.ToListAsync();
            ViewBag.bookList = booksList;
            return View();
        }

    }
}
