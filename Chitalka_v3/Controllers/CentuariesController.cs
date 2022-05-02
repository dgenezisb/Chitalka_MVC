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
    public class CentuariesController : Controller
    {
        private readonly Chitalka_v3Context _context;

        public CentuariesController(Chitalka_v3Context context)
        {
            _context = context;
        }

        // GET: Centuaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Centuary.ToListAsync());
        }

        // GET: Centuaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centuary = await _context.Centuary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centuary == null)
            {
                return NotFound();
            }

            return View(centuary);
        }

        // GET: Centuaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Centuaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Centuary centuary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centuary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centuary);
        }

        // GET: Centuaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centuary = await _context.Centuary.FindAsync(id);
            if (centuary == null)
            {
                return NotFound();
            }
            return View(centuary);
        }

        // POST: Centuaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Centuary centuary)
        {
            if (id != centuary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centuary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentuaryExists(centuary.Id))
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
            return View(centuary);
        }

        // GET: Centuaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centuary = await _context.Centuary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centuary == null)
            {
                return NotFound();
            }

            return View(centuary);
        }

        // POST: Centuaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centuary = await _context.Centuary.FindAsync(id);
            _context.Centuary.Remove(centuary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentuaryExists(int id)
        {
            return _context.Centuary.Any(e => e.Id == id);
        }
    }
}
