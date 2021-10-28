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
    public class HorarioClaseController : Controller
    {
        private readonly matriculaContext _context;

        public HorarioClaseController(matriculaContext context)
        {
            _context = context;
        }

        // GET: HorarioClase
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.HorarioClases.Include(h => h.PeriodoLectivo).Include(h => h.ProfesorNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: HorarioClase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioClase = await _context.HorarioClases
                .Include(h => h.PeriodoLectivo)
                .Include(h => h.ProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCurso == id);
            if (horarioClase == null)
            {
                return NotFound();
            }

            return View(horarioClase);
        }

        // GET: HorarioClase/Create
        public IActionResult Create()
        {
            ViewData["PeriodoActual"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "CursoCerrado");
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida");
            return View();
        }

        // POST: HorarioClase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCurso,NombreCurso,PeriodoActual,Ano,Aula,Profesor")] HorarioClase horarioClase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioClase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeriodoActual"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "CursoCerrado", horarioClase.PeriodoActual);
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", horarioClase.Profesor);
            return View(horarioClase);
        }

        // GET: HorarioClase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioClase = await _context.HorarioClases.FindAsync(id);
            if (horarioClase == null)
            {
                return NotFound();
            }
            ViewData["PeriodoActual"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "CursoCerrado", horarioClase.PeriodoActual);
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", horarioClase.Profesor);
            return View(horarioClase);
        }

        // POST: HorarioClase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCurso,NombreCurso,PeriodoActual,Ano,Aula,Profesor")] HorarioClase horarioClase)
        {
            if (id != horarioClase.CodigoCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioClase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioClaseExists(horarioClase.CodigoCurso))
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
            ViewData["PeriodoActual"] = new SelectList(_context.PeriodoLectivos, "NumeroPeriodo", "CursoCerrado", horarioClase.PeriodoActual);
            ViewData["Profesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", horarioClase.Profesor);
            return View(horarioClase);
        }

        // GET: HorarioClase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioClase = await _context.HorarioClases
                .Include(h => h.PeriodoLectivo)
                .Include(h => h.ProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCurso == id);
            if (horarioClase == null)
            {
                return NotFound();
            }

            return View(horarioClase);
        }

        // POST: HorarioClase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horarioClase = await _context.HorarioClases.FindAsync(id);
            _context.HorarioClases.Remove(horarioClase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioClaseExists(int id)
        {
            return _context.HorarioClases.Any(e => e.CodigoCurso == id);
        }
    }
}
