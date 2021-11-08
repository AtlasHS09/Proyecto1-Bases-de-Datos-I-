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
    public class AsistenciaEstudianteController : Controller
    {
        private readonly matriculaContext _context;

        public AsistenciaEstudianteController(matriculaContext context)
        {
            _context = context;
        }

        // GET: AsistenciaEstudiante
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.AsistenciaEstudiantes.Include(a => a.CedulaEstudianteNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: AsistenciaEstudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaEstudiante = await _context.AsistenciaEstudiantes
                .Include(a => a.CedulaEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (asistenciaEstudiante == null)
            {
                return NotFound();
            }

            return View(asistenciaEstudiante);
        }

        // GET: AsistenciaEstudiante/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual");
            return View();
        }

        // POST: AsistenciaEstudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,Porcentaje")] AsistenciaEstudiante asistenciaEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistenciaEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", asistenciaEstudiante.CedulaEstudiante);
            return View(asistenciaEstudiante);
        }

        // GET: AsistenciaEstudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaEstudiante = await _context.AsistenciaEstudiantes.FindAsync(id);
            if (asistenciaEstudiante == null)
            {
                return NotFound();
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", asistenciaEstudiante.CedulaEstudiante);
            return View(asistenciaEstudiante);
        }

        // POST: AsistenciaEstudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaEstudiante,Porcentaje")] AsistenciaEstudiante asistenciaEstudiante)
        {
            if (id != asistenciaEstudiante.CedulaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistenciaEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaEstudianteExists(asistenciaEstudiante.CedulaEstudiante))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", asistenciaEstudiante.CedulaEstudiante);
            return View(asistenciaEstudiante);
        }

        // GET: AsistenciaEstudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaEstudiante = await _context.AsistenciaEstudiantes
                .Include(a => a.CedulaEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (asistenciaEstudiante == null)
            {
                return NotFound();
            }

            return View(asistenciaEstudiante);
        }

        // POST: AsistenciaEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistenciaEstudiante = await _context.AsistenciaEstudiantes.FindAsync(id);
            _context.AsistenciaEstudiantes.Remove(asistenciaEstudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaEstudianteExists(int id)
        {
            return _context.AsistenciaEstudiantes.Any(e => e.CedulaEstudiante == id);
        }
    }
}
