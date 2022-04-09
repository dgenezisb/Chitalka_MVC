using Prr_stakan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<books> getAllBooks
        {
            get;
            set;
        }
        public string bookCat
        {
            get;
            set;
        }
    }
}
