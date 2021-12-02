using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMatriculaApp.Entities;

namespace WebMatriculaApp.Controllers
{
    public class CobroFacturaController : Controller
    {
        private readonly matricula4Context _context;

        public CobroFacturaController(matricula4Context context)
        {
            _context = context;
        }

        // GET: CobroFactura
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.CobroFacturas.Include(c => c.IdMatriculaNavigation).Include(c => c.IdPadreNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: CobroFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobroFactura = await _context.CobroFacturas
                .Include(c => c.IdMatriculaNavigation)
                .Include(c => c.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdCobroFactura == id);
            if (cobroFactura == null)
            {
                return NotFound();
            }

            return View(cobroFactura);
        }

        // GET: CobroFactura/Create
        public IActionResult Create()
        {
            ViewData["IdMatricula"] = new SelectList(_context.Matriculas, "IdMatricula", "IdMatricula");
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "Profesion");
            return View();
        }

        // POST: CobroFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCobroFactura,IdMatricula,NumeroMensualidad,IdPadre,Cantidad,FechaCobro,FechaFactura,Estado")] CobroFactura cobroFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobroFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMatricula"] = new SelectList(_context.Matriculas, "IdMatricula", "IdMatricula", cobroFactura.IdMatricula);
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "Profesion", cobroFactura.IdPadre);
            return View(cobroFactura);
        }

        // GET: CobroFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobroFactura = await _context.CobroFacturas.FindAsync(id);
            if (cobroFactura == null)
            {
                return NotFound();
            }
            ViewData["IdMatricula"] = new SelectList(_context.Matriculas, "IdMatricula", "IdMatricula", cobroFactura.IdMatricula);
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "Profesion", cobroFactura.IdPadre);
            return View(cobroFactura);
        }

        // POST: CobroFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCobroFactura,IdMatricula,NumeroMensualidad,IdPadre,Cantidad,FechaCobro,FechaFactura,Estado")] CobroFactura cobroFactura)
        {
            if (id != cobroFactura.IdCobroFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobroFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobroFacturaExists(cobroFactura.IdCobroFactura))
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
            ViewData["IdMatricula"] = new SelectList(_context.Matriculas, "IdMatricula", "IdMatricula", cobroFactura.IdMatricula);
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "Profesion", cobroFactura.IdPadre);
            return View(cobroFactura);
        }

        // GET: CobroFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobroFactura = await _context.CobroFacturas
                .Include(c => c.IdMatriculaNavigation)
                .Include(c => c.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdCobroFactura == id);
            if (cobroFactura == null)
            {
                return NotFound();
            }

            return View(cobroFactura);
        }

        // POST: CobroFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobroFactura = await _context.CobroFacturas.FindAsync(id);
            _context.CobroFacturas.Remove(cobroFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobroFacturaExists(int id)
        {
            return _context.CobroFacturas.Any(e => e.IdCobroFactura == id);
        }
    }
}
