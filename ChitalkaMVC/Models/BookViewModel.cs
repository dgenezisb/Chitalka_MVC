using ChitalkaMVC.Storage.Entities;

namespace ChitalkaMVC.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IFormFile? Image { get; set; }
        public int[] GenreIds { get; set; }
    }
}
