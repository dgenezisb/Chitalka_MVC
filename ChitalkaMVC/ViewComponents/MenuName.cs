using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class MenuName : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.username = HttpContext.Session.GetString("_Username");
            if (ViewBag.username == null)
                ViewBag.username = "Not Logged In";
            return View();
        }
    }
}
