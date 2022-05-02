using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chitalka_v3.Data;
using Chitalka_v3.Models;

namespace Chitalka_v3.Controllers
{
    public class Image2Controller : Controller
    {
        private readonly Chitalka_v3Context _context;

        public Image2Controller(Chitalka_v3Context context)
        {
            _context = context;
        }

        // GET: Image2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Image2.ToListAsync());
        }

        // GET: Image2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image2 = await _context.Image2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image2 == null)
            {
                return NotFound();
            }

            return View(image2);
        }

        // GET: Image2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,img")] Image2 image2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image2);
        }

        // GET: Image2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image2 = await _context.Image2.FindAsync(id);
            if (image2 == null)
            {
                return NotFound();
            }
            return View(image2);
        }

        // POST: Image2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,img")] Image2 image2)
        {
            if (id != image2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Image2Exists(image2.Id))
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
            return View(image2);
        }

        // GET: Image2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image2 = await _context.Image2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image2 == null)
            {
                return NotFound();
            }

            return View(image2);
        }

        // POST: Image2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image2 = await _context.Image2.FindAsync(id);
            _context.Image2.Remove(image2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Image2Exists(int id)
        {
            return _context.Image2.Any(e => e.Id == id);
        }
    }
}
