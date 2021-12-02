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
    public class InasistenciaEstudianteController : Controller
    {
        private readonly matricula4Context _context;

        public InasistenciaEstudianteController(matricula4Context context)
        {
            _context = context;
        }

        // GET: InasistenciaEstudiante
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.InasistenciaEstudiantes.Include(i => i.IdEstudianteNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: InasistenciaEstudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inasistenciaEstudiante = await _context.InasistenciaEstudiantes
                .Include(i => i.IdEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.IdInasistenciaE == id);
            if (inasistenciaEstudiante == null)
            {
                return NotFound();
            }

            return View(inasistenciaEstudiante);
        }

        // GET: InasistenciaEstudiante/Create
        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante");
            return View();
        }

        // POST: InasistenciaEstudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInasistenciaE,IdEstudiante,Fecha")] InasistenciaEstudiante inasistenciaEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inasistenciaEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", inasistenciaEstudiante.IdEstudiante);
            return View(inasistenciaEstudiante);
        }

        // GET: InasistenciaEstudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inasistenciaEstudiante = await _context.InasistenciaEstudiantes.FindAsync(id);
            if (inasistenciaEstudiante == null)
            {
                return NotFound();
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", inasistenciaEstudiante.IdEstudiante);
            return View(inasistenciaEstudiante);
        }

        // POST: InasistenciaEstudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInasistenciaE,IdEstudiante,Fecha")] InasistenciaEstudiante inasistenciaEstudiante)
        {
            if (id != inasistenciaEstudiante.IdInasistenciaE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inasistenciaEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InasistenciaEstudianteExists(inasistenciaEstudiante.IdInasistenciaE))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", inasistenciaEstudiante.IdEstudiante);
            return View(inasistenciaEstudiante);
        }

        // GET: InasistenciaEstudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inasistenciaEstudiante = await _context.InasistenciaEstudiantes
                .Include(i => i.IdEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.IdInasistenciaE == id);
            if (inasistenciaEstudiante == null)
            {
                return NotFound();
            }

            return View(inasistenciaEstudiante);
        }

        // POST: InasistenciaEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inasistenciaEstudiante = await _context.InasistenciaEstudiantes.FindAsync(id);
            _context.InasistenciaEstudiantes.Remove(inasistenciaEstudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InasistenciaEstudianteExists(int id)
        {
            return _context.InasistenciaEstudiantes.Any(e => e.IdInasistenciaE == id);
        }
    }
}
