using Microsoft.AspNetCore.Http;

namespace ChitalkaMVC.Logic.Books
{
    public interface IBookManager
    {
        Task<IList<Book>> GetAll();
        Task Create(Book book, IFormFile? image);
        Task SetGenresById(Book book, int[] ids);
        Task<Book> Find(int id);
        Task<bool> Update(Book book, IFormFile? image);
        Task Delete(int id);
    }
}
