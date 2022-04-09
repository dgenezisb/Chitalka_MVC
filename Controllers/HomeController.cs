using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prr_stakan.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBooks _allBooks;//мы связали класс и интерфейс,поэтому можно тупо к интерфесу обращаться и класс подгрузится
        private readonly IBooksCats _allCats;
        private readonly IBookYears _allYears;

        public HomeController(IAllBooks iAllBooks, IBooksCats iBooksCat, IBookYears iBookYears)
        {
            _allBooks = iAllBooks;
            _allCats = iBooksCat;
            _allYears = iBookYears;
        }

       

        public ViewResult Index()
        {
         
            var books = _allBooks.booksRet;
            var cats = _allCats.AllCats;
            var years = _allYears.AllYaers;
            return View(books);
            //alternativa

        }
    }
}
