namespace ChitalkaMVC.Logic.Authors
{
    public interface IAuthorManager
    {
        Task<IList<Author>> GetAll();
        Task Create();
        Task Delete(int id);
    }
}
