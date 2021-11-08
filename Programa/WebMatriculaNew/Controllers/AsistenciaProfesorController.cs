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
    public class AsistenciaProfesorController : Controller
    {
        private readonly matriculaContext _context;

        public AsistenciaProfesorController(matriculaContext context)
        {
            _context = context;
        }

        // GET: AsistenciaProfesor
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.AsistenciaProfesores.Include(a => a.CedulaProfesorNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: AsistenciaProfesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaProfesor = await _context.AsistenciaProfesores
                .Include(a => a.CedulaProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CedulaProfesor == id);
            if (asistenciaProfesor == null)
            {
                return NotFound();
            }

            return View(asistenciaProfesor);
        }

        // GET: AsistenciaProfesor/Create
        public IActionResult Create()
        {
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida");
            return View();
        }

        // POST: AsistenciaProfesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaProfesor,Porcentaje")] AsistenciaProfesor asistenciaProfesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistenciaProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", asistenciaProfesor.CedulaProfesor);
            return View(asistenciaProfesor);
        }

        // GET: AsistenciaProfesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaProfesor = await _context.AsistenciaProfesores.FindAsync(id);
            if (asistenciaProfesor == null)
            {
                return NotFound();
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", asistenciaProfesor.CedulaProfesor);
            return View(asistenciaProfesor);
        }

        // POST: AsistenciaProfesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaProfesor,Porcentaje")] AsistenciaProfesor asistenciaProfesor)
        {
            if (id != asistenciaProfesor.CedulaProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistenciaProfesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaProfesorExists(asistenciaProfesor.CedulaProfesor))
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", asistenciaProfesor.CedulaProfesor);
            return View(asistenciaProfesor);
        }

        // GET: AsistenciaProfesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaProfesor = await _context.AsistenciaProfesores
                .Include(a => a.CedulaProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CedulaProfesor == id);
            if (asistenciaProfesor == null)
            {
                return NotFound();
            }

            return View(asistenciaProfesor);
        }

        // POST: AsistenciaProfesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistenciaProfesor = await _context.AsistenciaProfesores.FindAsync(id);
            _context.AsistenciaProfesores.Remove(asistenciaProfesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaProfesorExists(int id)
        {
            return _context.AsistenciaProfesores.Any(e => e.CedulaProfesor == id);
        }
    }
}
