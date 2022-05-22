namespace ChitalkaMVC.Logic.UserBooks
{
    public class UserBookManager : IUserBookManager
    {
        private readonly ChitalkaContext _context;
        public UserBookManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task Create(string username, int bookId)
        {
            var item = new UserBook { UserId = username, BookId = bookId };
            _context.UserBook.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<UserBook>> GetByUsername(string username)
        {
            return await _context.UserBook.Where(ub => ub.UserId == username).Include(ub => ub.Book)
                .ThenInclude(b=>b.Author).ToListAsync();
        }

        public async Task<bool> Exists(string username, int bookId)
        {
            var ub = await _context.UserBook.FirstOrDefaultAsync(ub => ub.UserId == username && ub.BookId == bookId);
            if (ub == null)
                return false;
            else return true;
        }

        public async Task Delete(string username, int bookId)
        {
            var item = _context.UserBook.FirstOrDefault(ub => ub.BookId == bookId && ub.UserId == username);
            if (item != null)
            {
                _context.UserBook.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
