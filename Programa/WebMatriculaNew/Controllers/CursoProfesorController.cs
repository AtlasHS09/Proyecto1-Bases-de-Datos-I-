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
    public class CursoProfesorController : Controller
    {
        private readonly matriculaContext _context;

        public CursoProfesorController(matriculaContext context)
        {
            _context = context;
        }

        // GET: CursoProfesor
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.CursoProfesors.Include(c => c.PeriodoLectivo).Include(c => c.ProfesorNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: CursoProfesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoProfesor = await _context.CursoProfesors
                .Include(c => c.PeriodoLectivo)
                .Include(c => c.ProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCurso == id);
            if (cursoProfesor == null)
            {
                return NotFound();
            }

            return View(cursoProfesor);
        }

        // GET: CursoProfesor/Create
        public IActionResult Create()
        {
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo");
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor");
           
            return View();
        }

        // POST: CursoProfesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCurso,NombreCurso,Periodo,Ano,Aula,Profesor")] CursoProfesor cursoProfesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo", cursoProfesor.Periodo);
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor", cursoProfesor.Profesor);
            return View(cursoProfesor);
        }

        // GET: CursoProfesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoProfesor = await _context.CursoProfesors.FindAsync(id);
            if (cursoProfesor == null)
            {
                return NotFound();
            }
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo", cursoProfesor.Periodo);
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor", cursoProfesor.Profesor);
            return View(cursoProfesor);
        }

        // POST: CursoProfesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCurso,NombreCurso,Periodo,Ano,Aula,Profesor")] CursoProfesor cursoProfesor)
        {
            if (id != cursoProfesor.CodigoCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoProfesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoProfesorExists(cursoProfesor.CodigoCurso))
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
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "NumeroPeriodo", cursoProfesor.Periodo);
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor", cursoProfesor.Profesor);
            return View(cursoProfesor);
        }

        // GET: CursoProfesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoProfesor = await _context.CursoProfesors
                .Include(c => c.PeriodoLectivo)
                .Include(c => c.ProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCurso == id);
            if (cursoProfesor == null)
            {
                return NotFound();
            }

            return View(cursoProfesor);
        }

        // POST: CursoProfesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoProfesor = await _context.CursoProfesors.FindAsync(id);
            _context.CursoProfesors.Remove(cursoProfesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoProfesorExists(int id)
        {
            return _context.CursoProfesors.Any(e => e.CodigoCurso == id);
        }
    }
}
