namespace ChitalkaMVC.Logic.Books
{
    public interface IBookManager
    {
        Task<IList<Book>> GetAll();
        Task Create(Book book);
        Task SetGenresById(Book book, int[] ids);
        Task<Book> Find(int id);
        Task<bool> Update(Book book);
        Task Delete(int id);
    }
}
