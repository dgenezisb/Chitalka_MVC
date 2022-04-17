using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chitalka.Models;
//using Microsoft.Ajax.Utilities;

namespace Chitalka.Controllers
{
    public class HomeController : Controller
    {
        DBContext DBCont = new DBContext();
        public ActionResult Index()
        {
            //из таблички книг тыбзим данные
            IEnumerable<Books> books = DBCont.books;
            ViewBag.Books = books;
            return View();
        }
        [HttpGet]
        public ActionResult Show(int id)
        {
            var book = from User in DBCont.user.AsEnumerable()
                       where User.id == id
                       select User;
            
            ViewBag.book = book;
            return View();
        }
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            DBCont.user.Add(user);
            DBCont.SaveChanges();

            return View();
        }
        
    }
}