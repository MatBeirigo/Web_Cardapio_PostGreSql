using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCardapioSQL.Models;

namespace WebCardapioSQL.Controllers
{
    public class LancheController : Controller
    {
        private readonly Contexto _context;

        public LancheController(Contexto context)
        {
            _context = context;
        }

        // GET: Lanches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lanche.ToListAsync());
        }

        // GET: Lanches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lanche == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanche
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // GET: Lanches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lanches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lanche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lanche);
        }

        // GET: Lanches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lanche == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanche.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            return View(lanche);
        }

        // POST: Lanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Lanche lanche)
        {
            if (id != lanche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancheExists(lanche.Id))
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
            return View(lanche);
        }

        // GET: Lanches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lanche == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanche
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // POST: Lanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lanche == null)
            {
                return Problem("Entity set 'Contexto.Lanches'  is null.");
            }
            var lanche = await _context.Lanche.FindAsync(id);
            if (lanche != null)
            {
                _context.Lanche.Remove(lanche);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancheExists(int id)
        {
            return _context.Lanche.Any(e => e.Id == id);
        }
    }
}
