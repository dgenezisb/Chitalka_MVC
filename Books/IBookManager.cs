namespace ChitalkaMVC.Logic.Books
{
    public interface IBookManager
    {
        Task<IList<Book>> GetAll();
        Task Create();
        Task Delete(int id);
    }
}
