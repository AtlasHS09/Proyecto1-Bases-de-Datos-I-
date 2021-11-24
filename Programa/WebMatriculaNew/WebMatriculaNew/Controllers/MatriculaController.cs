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
    public class MatriculaController : Controller
    {
        private readonly matriculaContext _context;

        public MatriculaController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Matriculas.Include(m => m.CedulaEstudianteNavigation).Include(m => m.PeriodoLectivo);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.CedulaEstudianteNavigation)
                .Include(m => m.PeriodoLectivo)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual");
            ViewData["PeriodoMatricular"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,PeriodoMatricular,Anno,CobrosPendientes,MontoMatricula")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", matricula.CedulaEstudiante);
            ViewData["PeriodoMatricular"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo", matricula.PeriodoMatricular);
            return View(matricula);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", matricula.CedulaEstudiante);
            ViewData["PeriodoMatricular"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo", matricula.PeriodoMatricular);
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaEstudiante,PeriodoMatricular,Anno,CobrosPendientes,MontoMatricula")] Matricula matricula)
        {
            if (id != matricula.CedulaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.CedulaEstudiante))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", matricula.CedulaEstudiante);
            ViewData["PeriodoMatricular"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo", matricula.PeriodoMatricular);
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.CedulaEstudianteNavigation)
                .Include(m => m.PeriodoLectivo)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.CedulaEstudiante == id);
        }
    }
}
