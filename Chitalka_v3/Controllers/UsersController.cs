﻿using System;
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
    public class UsersController : Controller
    {
        private readonly Chitalka_v3Context _context;

        public UsersController(Chitalka_v3Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }
            var u = new CFUsers(_context);
            user = u.AddNotesToModel(user);
            return View(user);
        }

        public async Task<IActionResult> AddNote(int id,[Bind("note,id")] string note)
        {
            var n = new CFUsers(_context);
            //int id = Convert.ToInt32(id);
            
            var user = _context.User.Find(id);
            user = n.AddNotesToDB(user, note);
            _context.User.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,usrName,pswrd,ifAdmin,mail,ico")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Auth/5
        public IActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Auth([Bind("usrName,pswrd,mail")] User user)
        {
            if (ModelState.IsValid)
            {
                var u = new CFUsers(_context);
                bool? uCh = u.Auth(user);
                int? id = u.id(user);
                if (uCh == true)
                {
                    //return await Details(id);
                    return RedirectToAction(nameof(AuthOk));
                }
                else
                {
                    return RedirectToAction(nameof(AuthErr));
                }
               
            }
            return View();
        }

        //Обработчики фигни сверху
        public async Task<IActionResult> AuthOk()
        {
            return View();
        }
        public async Task<IActionResult> AuthErr()
        {
            return View();
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,usrName,pswrd,ifAdmin,mail,ico")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.id == id);
        }
    }
}
