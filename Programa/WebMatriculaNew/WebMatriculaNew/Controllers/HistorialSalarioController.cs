using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMatriculaNew.Entities;

namespace WebMatriculaNew.Controllers
{
    public class HistorialSalarioController : Controller
    {
        private readonly matriculaContext _context;

        public HistorialSalarioController(matriculaContext context)
        {
            _context = context;
        }

        // GET: HistorialSalario
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.HistorialSalarios.Include(h => h.CedulaProfesorNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: HistorialSalario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialSalario = await _context.HistorialSalarios
                .Include(h => h.CedulaProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CedulaProfesor == id);
            if (historialSalario == null)
            {
                return NotFound();
            }

            return View(historialSalario);
        }

        // GET: HistorialSalario/Create
        public IActionResult Create()
        {
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida");
            return View();
        }

        // POST: HistorialSalario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaProfesor,Salario,Fecha")] HistorialSalario historialSalario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialSalario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", historialSalario.CedulaProfesor);
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", historialSalario.CedulaProfesor);
            return View(historialSalario);
        }

        // POST: HistorialSalario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaProfesor,Salario,Fecha")] HistorialSalario historialSalario)
        {
            if (id != historialSalario.CedulaProfesor)
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
                    if (!HistorialSalarioExists(historialSalario.CedulaProfesor))
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", historialSalario.CedulaProfesor);
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
                .Include(h => h.CedulaProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CedulaProfesor == id);
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
            return _context.HistorialSalarios.Any(e => e.CedulaProfesor == id);
        }
    }
}
