using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SFF_Api_App.DB;
using SFF_Api_App.Models;

namespace SFF_Api_App.Controllers
{
    public class TriviasController : Controller
    {
        private readonly SFF_DbContext _context;

        public TriviasController(SFF_DbContext context)
        {
            _context = context;
        }

        // GET: Trivias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trivias.ToListAsync());
        }

        // GET: Trivias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trivias = await _context.Trivias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trivias == null)
            {
                return NotFound();
            }

            return View(trivias);
        }

        // GET: Trivias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trivias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Trivias trivias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trivias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trivias);
        }

        // GET: Trivias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trivias = await _context.Trivias.FindAsync(id);
            if (trivias == null)
            {
                return NotFound();
            }
            return View(trivias);
        }

        // POST: Trivias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Trivias trivias)
        {
            if (id != trivias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trivias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriviasExists(trivias.Id))
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
            return View(trivias);
        }

        // GET: Trivias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trivias = await _context.Trivias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trivias == null)
            {
                return NotFound();
            }

            return View(trivias);
        }

        // POST: Trivias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trivias = await _context.Trivias.FindAsync(id);
            _context.Trivias.Remove(trivias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TriviasExists(int id)
        {
            return _context.Trivias.Any(e => e.Id == id);
        }
    }
}
