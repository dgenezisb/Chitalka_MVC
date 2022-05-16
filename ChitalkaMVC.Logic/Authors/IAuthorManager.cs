namespace ChitalkaMVC.Logic.Authors
{
    public interface IAuthorManager
    {
        Task<IList<Author>> GetAll();
        Task Create(Author item);
        Task<Author> Find(int id);
        Task<bool> Update(Author author);
        Task Delete(int id);
    }
}
