using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitalkaMVC.Logic.Books
{
    public class BookFilterOptions
    {
        public string? AuthorName { get; set; }
        public string? Title { get; set; }
        public int[] GenreIds { get; set; }
    }
}
