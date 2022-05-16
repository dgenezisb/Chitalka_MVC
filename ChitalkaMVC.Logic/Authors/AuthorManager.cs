
namespace ChitalkaMVC.Logic.Authors
{
    public class AuthorManager : IAuthorManager
    {
        private ChitalkaContext _context;
        public AuthorManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task Create(Author item)
        {
            _context.Authors.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> Find(int id)
        {
            return await _context.Authors.Include(u => u.Country).FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<bool> Update(Author author)
        {
            try
            {
                _context.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = Find(author.Id);
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
            var item = _context.Authors.FirstOrDefault(item => item.Id == id);
            if (item != null)
            {
                _context.Authors.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Author>> GetAll() => await _context.Authors.Include(u => u.Country).ToListAsync();
    }
}
