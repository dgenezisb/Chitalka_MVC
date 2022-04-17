using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chitalka.Models;
namespace Chitalka.Controllers
{
    public class BooksController : Controller
    {
        DBContext DBCont = new DBContext();
        public ActionResult List()
        {
            
            IEnumerable<Books> books = DBCont.books;
            ViewBag.Books = books;
            return View();
        }
        [HttpGet]
        public ActionResult Show(int id)
        {
            var book = from Books in DBCont.books.AsEnumerable()
                       where Books.id == id
                       select Books;

            ViewBag.book = book;
            return View();
        }
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Books book)
        {
            DBCont.books.Add(book);
            DBCont.SaveChanges();
            var message = 1;
            ViewBag.message = message;
            return View();
        }
    }
}