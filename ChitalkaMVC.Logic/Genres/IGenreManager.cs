namespace ChitalkaMVC.Logic.Genres
{
    public interface IGenreManager
    {
        Task<IList<Genre>> GetAll();
        Task Create(string name);
        Task<Genre> Find(int id);
        Task<bool> Update(Genre genre);
        Task Delete(int id);
    }
}
