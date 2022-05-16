namespace ChitalkaMVC.Logic.Books
{
    public class BookManager : IBookManager
    {
        private readonly ChitalkaContext _context;
        public BookManager(ChitalkaContext context)
        {
            _context = context;
        }

        public async Task Create(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();
        }

        public async Task SetGenresById(Book book, int[] ids)
        {
            book.Genres = new List<Genre> { };
            foreach(int id in ids)
            {
                var genre = await _context.Genres.FindAsync(id);
                if (genre != null)
                    book.Genres.Add(genre);
            }
        }

        public async Task<Book> Find(int id)
        {
            return await _context.Books.Include(b=>b.Genres).Include(b=>b.Author)
                .Include(b=>b.Century).FirstOrDefaultAsync(b=>b.Id == id);
        }

        public async Task Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(Book book)
        {
            try
            {
                var existingBook = _context.Books.Include(b => b.Genres).FirstOrDefault(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.AuthorId = book.AuthorId;
                    existingBook.CenturyId = book.CenturyId;
                    existingBook.Text = book.Text;
                    existingBook.Name = book.Name;
                    existingBook.Description = book.Description;
                    existingBook.Visibility = book.Visibility;
                    var genresToRemove = new List<Genre> { };
                    foreach (var existingGenre in existingBook.Genres)
                    {
                        var genre = book.Genres.FirstOrDefault(g => g.Id == existingGenre.Id);
                        if (genre == null)
                        {
                            genresToRemove.Add(existingGenre);
                        }
                        else
                            book.Genres.Remove(genre);
                    }
                    foreach (var genre in genresToRemove)
                        existingBook.Genres.Remove(genre);
                    foreach (var genre in book.Genres)
                        existingBook.Genres.Add(genre);

                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = Find(book.Id);
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

        public async Task<IList<Book>> GetAll()
        {
            var books = await _context.Books.Include(b => b.Author).Include(b => b.Genres).Include(b => b.Century).ToListAsync();
            return books;
        }
    }
}
