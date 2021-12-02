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
    public class MatriculaController : Controller
    {
        private readonly matricula4Context _context;

        public MatriculaController(matricula4Context context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.Matriculas.Include(m => m.IdEstudianteNavigation).Include(m => m.PeriodoNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.IdEstudianteNavigation)
                .Include(m => m.PeriodoNavigation)
                .FirstOrDefaultAsync(m => m.IdMatricula == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante");
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMatricula,IdEstudiante,Periodo,CobrosPendientes,MontoMatricula")] Matricula matricula)
        {
            //if (ModelState.IsValid)
            //{
                //_context.Add(matricula);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", matricula.IdEstudiante);
            //ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo", matricula.Periodo);
           
             string sql = "Call matricularEstudiante(" + 
             matricula.IdEstudiante.ToString() + ", " + 
             matricula.Periodo.ToString() + ", " + 
             matricula.CobrosPendientes.ToString() + ", " + 
             matricula.MontoMatricula.ToString()+ ")";
             int result;
             using (var connection = _context.Database.GetDbConnection())
             {
                 await connection.OpenAsync();
                 using (var command = connection.CreateCommand())
                 {
                     command.CommandText = sql;
                     result = await command.ExecuteNonQueryAsync();
                 }
             }

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
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", matricula.IdEstudiante);
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo", matricula.Periodo);
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMatricula,IdEstudiante,Periodo,CobrosPendientes,MontoMatricula")] Matricula matricula)
        {
            if (id != matricula.IdMatricula)
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
                    if (!MatriculaExists(matricula.IdMatricula))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", matricula.IdEstudiante);
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo", matricula.Periodo);
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
                .Include(m => m.IdEstudianteNavigation)
                .Include(m => m.PeriodoNavigation)
                .FirstOrDefaultAsync(m => m.IdMatricula == id);
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
            return _context.Matriculas.Any(e => e.IdMatricula == id);
        }
    }
}
