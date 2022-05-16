namespace ChitalkaMVC.Logic.Countries
{
    public interface ICountryManager
    {
        Task<IList<Country>> GetAll();
        Task Create(string name);
        Task<Country> Find(int id);
        Task<bool> Update(Country country);
        Task Delete(int id);
    }
}
