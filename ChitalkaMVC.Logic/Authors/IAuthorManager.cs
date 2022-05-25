using Microsoft.AspNetCore.Http;

namespace ChitalkaMVC.Logic.Authors
{
    public interface IAuthorManager
    {
        Task<IList<Author>> GetAll();
        Task Create(Author item, IFormFile? image);
        Task<Author> Find(int id);
        Task<Author> GetFull(int id);
        Task<bool> Update(Author author, IFormFile? image);
        Task Delete(int id);
    }
}
