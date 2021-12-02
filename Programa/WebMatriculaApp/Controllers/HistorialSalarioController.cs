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
    public class HistorialSalarioController : Controller
    {
        private readonly matricula4Context _context;

        public HistorialSalarioController(matricula4Context context)
        {
            _context = context;
        }

        // GET: HistorialSalario
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.HistorialSalarios.Include(h => h.IdProfesorNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: HistorialSalario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialSalario = await _context.HistorialSalarios
                .Include(h => h.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (historialSalario == null)
            {
                return NotFound();
            }

            return View(historialSalario);
        }

        // GET: HistorialSalario/Create
        public IActionResult Create()
        {
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor");
            return View();
        }

        // POST: HistorialSalario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,Salario,Fecha")] HistorialSalario historialSalario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialSalario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", historialSalario.IdProfesor);
            return View(historialSalario);
        }

        // GET: HistorialSalario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialSalario = await _context.HistorialSalarios.FindAsync(id);
            if (historialSalario == null)
            {
                return NotFound();
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", historialSalario.IdProfesor);
            return View(historialSalario);
        }

        // POST: HistorialSalario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,Salario,Fecha")] HistorialSalario historialSalario)
        {
            if (id != historialSalario.IdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialSalario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialSalarioExists(historialSalario.IdProfesor))
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", historialSalario.IdProfesor);
            return View(historialSalario);
        }

        // GET: HistorialSalario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialSalario = await _context.HistorialSalarios
                .Include(h => h.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (historialSalario == null)
            {
                return NotFound();
            }

            return View(historialSalario);
        }

        // POST: HistorialSalario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialSalario = await _context.HistorialSalarios.FindAsync(id);
            _context.HistorialSalarios.Remove(historialSalario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialSalarioExists(int id)
        {
            return _context.HistorialSalarios.Any(e => e.IdProfesor == id);
        }
    }
}
