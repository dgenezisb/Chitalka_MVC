namespace ChitalkaMVC.Logic.Centuries
{
    public interface ICenturyManager
    {
        Task<IList<Century>> GetAll();
        Task Create(string name);
        Task<Century> Find(int id);
        Task<bool> Update(Century century);
        Task Delete(int id);
    }
}
