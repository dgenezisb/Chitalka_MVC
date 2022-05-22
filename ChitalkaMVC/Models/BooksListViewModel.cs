using ChitalkaMVC.Storage.Entities;
using ChitalkaMVC.Logic.Books;

namespace ChitalkaMVC.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book>? Books { get; set; }
        public BookFilterOptions Options { get; set; }
    }
}
