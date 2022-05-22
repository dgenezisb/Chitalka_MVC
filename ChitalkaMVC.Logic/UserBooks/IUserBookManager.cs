namespace ChitalkaMVC.Logic.UserBooks
{
    public interface IUserBookManager
    {
        Task Create(string username, int bookId);
        Task<bool> Exists(string username, int bookId);
        Task<IList<UserBook>> GetByUsername(string username);
        Task Delete(string username, int bookId);
    }
}
