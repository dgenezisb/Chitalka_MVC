using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
