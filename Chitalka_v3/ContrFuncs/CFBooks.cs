using Microsoft.EntityFrameworkCore;
using Chitalka_v3.Data;
using Chitalka_v3.Models;

namespace Chitalka_v3.ContrFuncs
{
    public class CFBooks
    {
        private readonly Chitalka_v3Context _context;
        public CFBooks(Chitalka_v3Context context)
        {
            _context = context;
        }

        //
        //Add
        //
        public void Add(string inpImage, string inpAuthor, string inpCentuary, string inpCountry, string inpGenre)
        {
            var Img = AddImg(inpImage);
            var Auth = AddAuthor(inpAuthor);
            var Cent = AddCent(inpCentuary);
            var Country = AddCoutry(inpCountry);
            var Genre = AddGenre(inpGenre);
            
        }
        public Books AddB(Books book)
        {
            book.Image = AddImg(book.inpImage);
            book.Author = AddAuthor(book.inpAuthor);
            book.Centuary = AddCent(book.inpCentuary);
            book.Country = AddCoutry(book.inpCountry);
            book.Genre = AddGenre(book.inpGenre);
            book.inpCentuary = null;
            book.inpGenre = null;
            book.inpAuthor = null;
            book.inpCountry = null;
            book.inpImage = null;
            return book;
        }

        private Image AddImg(string inpImage)
        {
            var i = new Image();
            i.book = inpImage;
            _context.Image.Add(i);
           
            return i;
        }
        private Author AddAuthor(string inpAuthor)
        {
            var i = new Author();
            i.Name = inpAuthor;
            _context.Author.Add(i);
            return i;
        }
        private Centuary AddCent(string inpCentuary)
        {
            var i = new Centuary();
            i.Name = inpCentuary;
            _context.Centuary.Add(i);
            return i;
        }
        private Country AddCoutry(string inpCountry)
        {
            var i = new Country();
            i.Name = inpCountry;
            _context.Country.Add(i);
            return i;
        }
        private Genre AddGenre(string inpGenre)
        {
            var i = new Genre();
            i.Name = inpGenre;
            _context.Genre.Add(i);
            return i;
        }
        //
        //Edit
        //
        public Books Edit(Books books)
        {
            books.Image = EditImg(books.inpImage);
            books.Author = EditAuthor(books.inpAuthor);
            books.Centuary = EditCent(books.inpCentuary);
            books.Country = EditCountry(books.inpCountry);
            books.Genre = EditGenre(books.inpGenre);
            return books;
        }
        private Image EditImg(string inpImage)
        {
            var i = new Image();
            i.book = inpImage;
            _context.Image.Update(i);
            return i;
        }
        private Author EditAuthor(string inpAuthor)
        {
            var i = new Author();
            i.Name = inpAuthor;
            _context.Author.Update(i);
            return i;
        }
        private Centuary EditCent(string inpCentuary)
        {
            var i = new Centuary();
            i.Name = inpCentuary;
            _context.Centuary.Update(i);
            return i;
        }
        private Country EditCountry(string inpCountry)
        {
            var i = new Country();
            i.Name = inpCountry;
            _context.Country.Update(i);
            return i;
        }
        private Genre EditGenre(string inpGenre)
        {
            var i = new Genre();
            i.Name = inpGenre;
            _context.Genre.Update(i);
            return i;
        }
        //
        //Remove (potnoe i dushnoe mesto,a pivo-to konchaentsa...) 
        //
        public Books Remove(Books book)
        {

            var iImg = book.ImageId;
            var iAuthor = book.AuthorId;
            var iCent = book.CentuaryId;
            var iCountry = book.CountryId;
            var iGenre = book.Genreid;

            book.Image = RevomeImg(iImg);
            book.Author = RevomeAuthor(iAuthor);
            book.Centuary = RevomeCentuary(iCent);
            book.Country = RevomeCountry(iCountry);
            book.Genre = RevomeGenre(iGenre);
            return book;
        }
        private Image RevomeImg(int? id)
        {
            var i = _context.Image.Find(id);
            _context.Image.Remove(i);
            return i;
        }
        private Author RevomeAuthor(int? id)
        {
            var i = _context.Author.Find(id);
            _context.Author.Remove(i);
            return i;
        }
        private Centuary RevomeCentuary(int? id)
        {
            var i = _context.Centuary.Find(id);
            _context.Centuary.Remove(i);
            return i;
        }
        private Country RevomeCountry(int? id)
        {
            var i = _context.Country.Find(id);
            _context.Country.Remove(i);
            return i;
        }
        private Genre RevomeGenre(int? id)
        {
            var i = _context.Genre.Find(id);
            _context.Genre.Remove(i);
            return i;
        }
        //
        //Show
        //
        public Books Show(Books books)
        {
            books.Author = _context.Author.Find(books.AuthorId);
            books.Centuary = _context.Centuary.Find(books.CentuaryId);
            books.Genre = _context.Genre.Find(books.Genreid);
            books.Image = _context.Image.Find(books.ImageId);
            books.Country = _context.Country.Find(books.CountryId);
            return books;
        }
    }
}
