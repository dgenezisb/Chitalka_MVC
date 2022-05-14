namespace ChitalkaMVC.Logic.Countries
{
    public class CountryManager : ICountryManager
    {
        private readonly ChitalkaContext _context;

        public CountryManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task Create(string name)
        {
            var country = new Country { Name = name };

            _context.Countries.Add(country);

            await _context.SaveChangesAsync();
        }

        public async Task<Country> Find(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<bool> Update(Country country)
        {
            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = Find(country.Id);
                if (item == null)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task Delete(int id)
        {
            var country = _context.Countries.FirstOrDefault(country => country.Id == id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Country>> GetAll() => await _context.Countries.ToListAsync();

    }
}
