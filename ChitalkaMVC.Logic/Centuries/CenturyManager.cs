namespace ChitalkaMVC.Logic.Centuries
{
    public class CenturyManager : ICenturyManager
    {
        private readonly ChitalkaContext _context;

        public CenturyManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task Create(string name)
        {
            var century = new Century { Name = name };
            
            _context.Centuries.Add(century);

            await _context.SaveChangesAsync();
        }

        public async Task<Century> Find(int id)
        {
            return await _context.Centuries.FindAsync(id);
        }

        public async Task<bool> Update(Century century)
        {
            try
            {
                _context.Update(century);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = Find(century.Id);
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
            var century = _context.Centuries.FirstOrDefault(century => century.Id == id);
            if (century != null)
            {
                _context.Centuries.Remove(century);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Century>> GetAll() => await _context.Centuries.ToListAsync();
        
    }
}
