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
    public class NotumController : Controller
    {
        private readonly matriculaContext _context;

        public NotumController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Notum
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Nota.Include(n => n.CedulaEstudianteNavigation).Include(n => n.CodigoEvaluacionNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Notum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.CedulaEstudianteNavigation)
                .Include(n => n.CodigoEvaluacionNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEvaluacion == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // GET: Notum/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual");
            ViewData["CodigoEvaluacion"] = new SelectList(_context.Evaluacions, "CodigoEvaluacion", "Evaluacion1");
            return View();
        }

        // POST: Notum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEvaluacion,CedulaEstudiante,Resultado")] Notum notum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", notum.CedulaEstudiante);
            ViewData["CodigoEvaluacion"] = new SelectList(_context.Evaluacions, "CodigoEvaluacion", "Evaluacion1", notum.CodigoEvaluacion);
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", notum.CedulaEstudiante);
            ViewData["CodigoEvaluacion"] = new SelectList(_context.Evaluacions, "CodigoEvaluacion", "Evaluacion1", notum.CodigoEvaluacion);
            return View(notum);
        }

        // POST: Notum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEvaluacion,CedulaEstudiante,Resultado")] Notum notum)
        {
            if (id != notum.CodigoEvaluacion)
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
                    if (!NotumExists(notum.CodigoEvaluacion))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", notum.CedulaEstudiante);
            ViewData["CodigoEvaluacion"] = new SelectList(_context.Evaluacions, "CodigoEvaluacion", "Evaluacion1", notum.CodigoEvaluacion);
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
                .Include(n => n.CedulaEstudianteNavigation)
                .Include(n => n.CodigoEvaluacionNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEvaluacion == id);
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
            return _context.Nota.Any(e => e.CodigoEvaluacion == id);
        }
    }
}
