using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ChitalkaMVC.Logic.Authors
{
    public class AuthorManager : IAuthorManager
    {
        private readonly ChitalkaContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private static readonly string _defaultImage = @"\Images\defaultauthor.png";
        public AuthorManager(ChitalkaContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        //Returns path that leads to the created image, or default image path if the passed image is null
        private async Task<string> CreateImage(IFormFile? image)
        {
            string root = _hostEnvironment.WebRootPath;
            string path;
            if (image != null)
            {
                string extension = Path.GetExtension(image.FileName);
                string filename = Path.GetFileNameWithoutExtension(image.FileName) + DateTime.Now.ToString("yymmssfff") + extension;
                path = Path.Combine("\\Images\\Authors\\", filename);
                var filepath = Path.Combine(root + "\\Images\\Authors\\", filename);
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
        public async Task Create(Author item, IFormFile? image)
        {
            item.ImagePath = await CreateImage(image);
            _context.Authors.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> Find(int id)
        {
            return await _context.Authors.Include(u => u.Country).FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<bool> Update(Author author, IFormFile? image)
        {
            try
            {
                if (image != null)
                {
                    if (author.ImagePath != _defaultImage)
                        DeleteImage(author.ImagePath);
                    author.ImagePath = await CreateImage(image);
                }
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
                if(item.ImagePath != _defaultImage)
                    DeleteImage(item.ImagePath);
                _context.Authors.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Author>> GetAll() => await _context.Authors.Include(u => u.Country).ToListAsync();
    }
}
