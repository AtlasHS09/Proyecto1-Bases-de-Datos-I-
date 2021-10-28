using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMatricula.Entities;

namespace WebMatricula.Controllers
{
    public class PeriodoLectivoController : Controller
    {
        private readonly matriculaContext _context;

        public PeriodoLectivoController(matriculaContext context)
        {
            _context = context;
        }

        // GET: PeriodoLectivo
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.PeriodoLectivos.Include(p => p.CedulaEstudianteNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: PeriodoLectivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .Include(p => p.CedulaEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.NumeroPeriodo == id);
            if (periodoLectivo == null)
            {
                return NotFound();
            }

            return View(periodoLectivo);
        }

        // GET: PeriodoLectivo/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual");
            return View();
        }

        // POST: PeriodoLectivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroPeriodo,Ano,FechaInicio,FechaFinal,CursoCerrado,CursoPendiente,CedulaEstudiante")] PeriodoLectivo periodoLectivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodoLectivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", periodoLectivo.CedulaEstudiante);
            return View(periodoLectivo);
        }

        // GET: PeriodoLectivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos.FindAsync(id);
            if (periodoLectivo == null)
            {
                return NotFound();
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", periodoLectivo.CedulaEstudiante);
            return View(periodoLectivo);
        }

        // POST: PeriodoLectivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroPeriodo,Ano,FechaInicio,FechaFinal,CursoCerrado,CursoPendiente,CedulaEstudiante")] PeriodoLectivo periodoLectivo)
        {
            if (id != periodoLectivo.NumeroPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodoLectivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoLectivoExists(periodoLectivo.NumeroPeriodo))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CursoActual", periodoLectivo.CedulaEstudiante);
            return View(periodoLectivo);
        }

        // GET: PeriodoLectivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .Include(p => p.CedulaEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.NumeroPeriodo == id);
            if (periodoLectivo == null)
            {
                return NotFound();
            }

            return View(periodoLectivo);
        }

        // POST: PeriodoLectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periodoLectivo = await _context.PeriodoLectivos.FindAsync(id);
            _context.PeriodoLectivos.Remove(periodoLectivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoLectivoExists(int id)
        {
            return _context.PeriodoLectivos.Any(e => e.NumeroPeriodo == id);
        }
    }
}