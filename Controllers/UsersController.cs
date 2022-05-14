using ChitalkaMVC.Logic.Users;
using ChitalkaMVC.Models;
using ChitalkaMVC.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserManager _manager;
        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserViewModel { Result = " " });
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var authRes = (auth: false, admin: false);
                authRes = await _manager.Find(user);
                if (authRes.auth)
                {
                    HttpContext.Session.SetString("_Username", user.Username);
                    HttpContext.Session.SetInt32("_Auth", 1);
                    if (authRes.admin)
                        HttpContext.Session.SetInt32("_IsAdmin", 1);
                    else
                        HttpContext.Session.SetInt32("_IsAdmin", 0);
                    return View(new UserViewModel { Result = "Success!", User = user });
                }
                return View(new UserViewModel { Result = "Incorrect password or user does not exist", User = user });
            }
            return View(new UserViewModel { Result = "Check your input", User = user });
        }

        [HttpGet]
        public IActionResult Profile()
        {
            ViewBag.session = HttpContext.Session.Id;
            ViewBag.isadmin = HttpContext.Session.GetInt32("_IsAdmin");
            ViewBag.auth = HttpContext.Session.GetInt32("_Auth");
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [Route("users/logout")]
        public IActionResult LogoutConfirmed()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserViewModel { Result = " "});
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (await _manager.Create(user))
                {
                    return RedirectToAction(nameof(Login));
                    //return View(new UserViewModel { Result = "Success!", User = user });
                }
                return View(new UserViewModel { Result = "User already exists", User = user });
            }
            return View(new UserViewModel { Result = "Check your input", User = user });
        }
    }
}
