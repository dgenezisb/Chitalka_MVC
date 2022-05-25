namespace ChitalkaMVC.Logic.Users
{
    public interface IUserManager
    {
        Task<IList<User>> GetAll();
        Task<bool> Create(User user);
        Task<(bool, bool)> Find(User user);
        Task<bool> Update(User user);
        Task<User> Get(string username);
        Task<User> GetByMail(string mail);
        Task Delete(string username);
    }
}
