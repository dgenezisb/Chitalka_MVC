namespace ChitalkaMVC.Logic.Genres
{
    public class GenreManager : IGenreManager
    {
        private readonly ChitalkaContext _context;

        public GenreManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task Create(string name)
        {
            var genre = new Genre { Name = name };

            _context.Genres.Add(genre);

            await _context.SaveChangesAsync();
        }

        public async Task<Genre> Find(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<bool> Update(Genre genre)
        {
            try
            {
                _context.Update(genre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = Find(genre.Id);
                if (item==null)
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
            var genre = _context.Genres.FirstOrDefault(genre => genre.Id == id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Genre>> GetAll() => await _context.Genres.ToListAsync();

    }
}
