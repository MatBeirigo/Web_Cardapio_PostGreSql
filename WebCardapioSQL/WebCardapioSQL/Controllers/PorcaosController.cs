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
    public class PorcaosController : Controller
    {
        private readonly Contexto _context;

        public PorcaosController(Contexto context)
        {
            _context = context;
        }

        // GET: Porcaos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Porcao.ToListAsync());
        }

        // GET: Porcaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Porcao == null)
            {
                return NotFound();
            }

            var porcao = await _context.Porcao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porcao == null)
            {
                return NotFound();
            }

            return View(porcao);
        }

        // GET: Porcaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Porcaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Porcao porcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(porcao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porcao);
        }

        // GET: Porcaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Porcao == null)
            {
                return NotFound();
            }

            var porcao = await _context.Porcao.FindAsync(id);
            if (porcao == null)
            {
                return NotFound();
            }
            return View(porcao);
        }

        // POST: Porcaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Porcao porcao)
        {
            if (id != porcao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(porcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorcaoExists(porcao.Id))
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
            return View(porcao);
        }

        // GET: Porcaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Porcao == null)
            {
                return NotFound();
            }

            var porcao = await _context.Porcao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porcao == null)
            {
                return NotFound();
            }

            return View(porcao);
        }

        // POST: Porcaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Porcao == null)
            {
                return Problem("Entity set 'Contexto.Porcao'  is null.");
            }
            var porcao = await _context.Porcao.FindAsync(id);
            if (porcao != null)
            {
                _context.Porcao.Remove(porcao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorcaoExists(int id)
        {
          return _context.Porcao.Any(e => e.Id == id);
        }
    }
}
