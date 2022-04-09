using Microsoft.AspNetCore.Mvc;
using Prr_stakan.Data.interfaces;
using Prr_stakan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prr_stakan.Data.Models;

namespace Prr_stakan.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks _allBooks;//мы связали класс и интерфейс,поэтому можно тупо к интерфесу обращаться и класс подгрузится
        private readonly IBooksCats _allCats;

        public BooksController(IAllBooks iAllBooks,IBooksCats iBooksCat)
        {
            _allBooks = iAllBooks;
            _allCats = iBooksCat;   
        }

        [Route("Books/List")]
        [Route("Books/List/{category}")]
        [Route("Books/List/{category}/{id}")]
        public ViewResult List(string category)
        {
            string _category = category;
            
            IEnumerable<books> books1 = _allBooks.booksRet;
           
            if (string.IsNullOrEmpty(category))
            {
                books1 = _allBooks.booksRet.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("Roman",category,StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Роман")).OrderBy(i => i.id);
                }
                if (string.Equals("Horror", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Ужас")).OrderBy(i => i.id);
                }
                if (string.Equals("Dram", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Драма")).OrderBy(i => i.id);
                }
                if (string.Equals("Epos", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Эпос")).OrderBy(i => i.id);
                }
                if (string.Equals("Novell", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Новелла")).OrderBy(i => i.id);
                }
                if (string.Equals("Poem", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Поэма")).OrderBy(i => i.id);
                }
                if (string.Equals("Passkaz", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Рассказ")).OrderBy(i => i.id);
                }
                if (string.Equals("Skazka", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Сказка")).OrderBy(i => i.id);
                }
                if (string.Equals("Epopeya", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Эпопея")).OrderBy(i => i.id);
                }
                if (string.Equals("Povest", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Повесть")).OrderBy(i => i.id);
                }
                if (string.Equals("hronika", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Хроника")).OrderBy(i => i.id);
                }
                if (string.Equals("Oda", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Ода")).OrderBy(i => i.id);
                }
                if (string.Equals("Romans", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Романс")).OrderBy(i => i.id);
                }
                if (string.Equals("Tragedy", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Трагедия")).OrderBy(i => i.id);
                }
                if (string.Equals("Melodram", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Мелодрамма")).OrderBy(i => i.id);
                }
                if (string.Equals("Comedy", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Комедия")).OrderBy(i => i.id);
                }
                if (string.Equals("Fars", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Фарс")).OrderBy(i => i.id);
                }
                if (string.Equals("Satire", category, StringComparison.OrdinalIgnoreCase))
                {
                    books1 = _allBooks.booksRet.Where(i => i.Category.categoryName.Equals("Сатира")).OrderBy(i => i.id);
                }

            }
           
          
            ViewBag.Category = "bla-bla";
            var books = _allBooks.booksRet;
;
            return View(books1);
            //alternativa
           
        }
        public ViewResult ShowEach(string id)
        {
            string _id = id;
            IEnumerable<books> books1 = _allBooks.booksRet;
            var bookRet = _allBooks.booksRet;
            foreach (var check in books1)
            {
                if (string.Equals(check.id.ToString(), _id, StringComparison.OrdinalIgnoreCase))
                {
                    //bookRet = _allBooks.booksRet.Where(i => i.id.Equals());
                }
            }
            return View(books1);
        }
    }
}
