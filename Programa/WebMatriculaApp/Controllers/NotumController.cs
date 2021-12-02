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
    public class NotumController : Controller
    {
        private readonly matricula4Context _context;

        public NotumController(matricula4Context context)
        {
            _context = context;
        }

        // GET: Notum
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.Nota.Include(n => n.IdEstudianteNavigation).Include(n => n.IdEvaluacionNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: Notum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.IdEstudianteNavigation)
                .Include(n => n.IdEvaluacionNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // GET: Notum/Create
        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante");
            ViewData["IdEvaluacion"] = new SelectList(_context.Evaluacions, "IdEvaluacion", "Evaluacion1");
            return View();
        }

        // POST: Notum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNota,IdEvaluacion,IdEstudiante,Resultado")] Notum notum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", notum.IdEstudiante);
            ViewData["IdEvaluacion"] = new SelectList(_context.Evaluacions, "IdEvaluacion", "Evaluacion1", notum.IdEvaluacion);
            return View(notum);
        }

        // GET: Notum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota.FindAsync(id);
            if (notum == null)
            {
                return NotFound();
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", notum.IdEstudiante);
            ViewData["IdEvaluacion"] = new SelectList(_context.Evaluacions, "IdEvaluacion", "Evaluacion1", notum.IdEvaluacion);
            return View(notum);
        }

        // POST: Notum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,IdEvaluacion,IdEstudiante,Resultado")] Notum notum)
        {
            if (id != notum.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotumExists(notum.IdNota))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", notum.IdEstudiante);
            ViewData["IdEvaluacion"] = new SelectList(_context.Evaluacions, "IdEvaluacion", "Evaluacion1", notum.IdEvaluacion);
            return View(notum);
        }

        // GET: Notum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.IdEstudianteNavigation)
                .Include(n => n.IdEvaluacionNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // POST: Notum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notum = await _context.Nota.FindAsync(id);
            _context.Nota.Remove(notum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotumExists(int id)
        {
            return _context.Nota.Any(e => e.IdNota == id);
        }
    }
}
