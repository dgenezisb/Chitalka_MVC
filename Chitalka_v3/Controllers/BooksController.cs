using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chitalka_v3.Data;
using Chitalka_v3.Models;

using Chitalka_v3.ContrFuncs;


namespace Chitalka_v3.Controllers
{
    public class BooksController : Controller
    {
        private readonly Chitalka_v3Context _context;

        public BooksController(Chitalka_v3Context context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .FirstOrDefaultAsync(m => m.id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,bookInside,bookName,descriprionBook,inpImage,inpAuthor,inpCentuary,inpCountry,inpGenre")] Books books)
        {
            if (ModelState.IsValid)
            {
                var Add = new CFBooks(_context);
                books = Add.AddB(books);
                //Add.Add(books.inpImage, books.inpAuthor, books.inpCentuary, books.inpCountry, books.inpGenre);
                //books.inpCentuary = null;
                //books.inpGenre = null;
                //books.inpAuthor = null;
                //books.inpCountry = null;
                //books.inpImage = null;

                _context.Add(books);
                await _context.SaveChangesAsync();
                var b = books;
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(CreateTb("books.inpAuthor,books.bookName"));
            }
            return View(books);
        }
        

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            var i = new CFBooks(_context);
            books = i.Show(books);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("id,bookInside,bookName,descriprionBook,inpImage,inpAuthor,inpCentuary,inpCountry,inpGenre")] Books books)

        {
            if (id != books.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    var show = new CFBooks(_context);
                    books = show.Show(books);
                    var Edit = new CFBooks(_context);
                    Edit.Edit(books);
                    books.inpCentuary = null;
                    books.inpGenre = null;
                    books.inpAuthor = null;
                    books.inpCountry = null;
                    books.inpImage = null;
                    
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .FirstOrDefaultAsync(m => m.id == id);
            if (books == null)
            {
                return NotFound();
            }
            var show = new CFBooks(_context);
            books = show.Show(books);
            
            //var a = books;
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Books.FindAsync(id);
            var show = new CFBooks(_context);
            books = show.Show(books);
            var remove = new CFBooks(_context);
            remove.Remove(books);
            
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.id == id);
        }
    }
}
