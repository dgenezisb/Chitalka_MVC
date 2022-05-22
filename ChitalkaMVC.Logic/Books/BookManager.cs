using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ChitalkaMVC.Logic.Books
{
    public class BookManager : IBookManager
    {
        private readonly ChitalkaContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private static readonly string _defaultImage = @"\Images\defaultbook.png";
        public BookManager(ChitalkaContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostEnvironment = webHostEnvironment;
        }

        private async Task<string> CreateImage(IFormFile? image)
        {
            string root = _hostEnvironment.WebRootPath;
            string path;
            if (image != null)
            {
                string extension = Path.GetExtension(image.FileName);
                string filename = Path.GetFileNameWithoutExtension(image.FileName) + DateTime.Now.ToString("yymmssfff") + extension;
                path = Path.Combine("\\Images\\Books\\", filename);
                var filepath = Path.Combine(root + "\\Images\\Books\\", filename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    await image.CopyToAsync(filestream);
                }
            }
            else
                path = _defaultImage;
            return path;
        }
        private void DeleteImage(string imagepath)
        {
            if (imagepath == _defaultImage)
                return;
            var root = _hostEnvironment.WebRootPath;
            imagepath = root + imagepath;
            if (System.IO.File.Exists(imagepath))
                System.IO.File.Delete(imagepath);
        }

        public async Task Create(Book book, IFormFile? image)
        {
            book.ImagePath = await CreateImage(image);
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
                if (book.ImagePath != _defaultImage)
                    DeleteImage(book.ImagePath);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(Book book, IFormFile? image)
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
                    if (image != null)
                    {
                        if (book.ImagePath != _defaultImage)
                            DeleteImage(book.ImagePath);
                        book.ImagePath = await CreateImage(image);
                    }
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
