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
    public class EstudianteController : Controller
    {
        private readonly matricula4Context _context;
        public EstudianteController(matricula4Context context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.Estudiantes.Include(e => e.IdEstudianteNavigation).Include(e => e.IdPadreNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.IdEstudianteNavigation)
                .Include(e => e.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula");
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "IdPadre");
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,Periodo,GradoActual,IdPadre")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", estudiante.IdEstudiante);
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "IdPadre", estudiante.IdPadre);
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", estudiante.IdEstudiante);
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "Profesion", estudiante.IdPadre);
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,Periodo,GradoActual,IdPadre")] Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.IdEstudiante))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", estudiante.IdEstudiante);
            ViewData["IdPadre"] = new SelectList(_context.Padres, "IdPadre", "Profesion", estudiante.IdPadre);
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.IdEstudianteNavigation)
                .Include(e => e.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.IdEstudiante == id);
        }
        public IActionResult Ponderado(int? id)
        {
            List<Ponderado> list;
            string sql = "CALL promedioPonderadoXestudianteParticular(" + id + ")";
            list = _context.Ponderados.FromSqlRaw<Ponderado>(sql).ToList();

            return View(list);
        }
        public IActionResult Ausencia(int? id)
        {
            List<AusenciaParticular> list;
            string sql = "CALL EstudiantesAusenciasParticular(" + id + ")";
            list = _context.AusenciaParticulars.FromSqlRaw<AusenciaParticular>(sql).ToList();
            return View(list);
        }


    }
}
