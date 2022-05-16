namespace ChitalkaMVC.Logic.Users
{
    public interface IUserManager
    {
        Task<IList<User>> GetAll();
        Task<bool> Create(User user);
        Task<(bool, bool)> Find(User user);
        Task Delete(string username);
    }
}
