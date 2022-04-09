using Microsoft.AspNetCore.Mvc;
using Prr_stakan.Data.interfaces;
using Prr_stakan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBooksCats _AllCats;//мы связали класс и интерфейс,поэтому можно тупо к интерфесу обращаться и класс подгрузится

        public CategoryController(IBooksCats iCats)
        {
           
            _AllCats = iCats;
            
        }
        public ViewResult List()
        {
            
            var books = _AllCats.AllCats;
            return View(books);
            //alternativa

        }
    }
}

