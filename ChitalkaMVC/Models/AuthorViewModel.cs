using ChitalkaMVC.Storage.Entities;

namespace ChitalkaMVC.Models
{
    public class AuthorViewModel
    {
        public Author Author { get; set; }
        public IFormFile? Image { get; set; }
        
    }
}
