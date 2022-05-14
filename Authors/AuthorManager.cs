
namespace ChitalkaMVC.Logic.Authors
{
    public class AuthorManager : IAuthorManager
    {
        private ChitalkaContext _context;
        public AuthorManager(ChitalkaContext context)
        {
            _context = context;
        }
        public Task Create()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Author>> GetAll() => await _context.Authors.Include(u => u.Country).ToListAsync();
    }
}
