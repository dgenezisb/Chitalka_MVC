using ChitalkaMVC.Logic.Authors;
using ChitalkaMVC.Storage.Entities;

namespace ChitalkaMVC.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Author>? Authors { get; set; }
        public AuthorFilterOptions Options { get; set; }
    }
}
