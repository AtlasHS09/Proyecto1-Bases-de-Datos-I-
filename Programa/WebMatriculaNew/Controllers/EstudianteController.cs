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
    public class EstudianteController : Controller
    {
        private readonly matriculaContext _context;

        public EstudianteController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Estudiantes.Include(e => e.CedulaEstudianteNavigation).Include(e => e.CedulaPadreNavigation).Include(e => e.GrupoNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CedulaEstudianteNavigation)
                .Include(e => e.CedulaPadreNavigation)
                .Include(e => e.GrupoNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto");
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "Profesion");
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado");
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,GradosCursados,Periodo,CursoActual,EstadoPeriodo,CedulaPadre,Grupo")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", estudiante.CedulaEstudiante);
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "Profesion", estudiante.CedulaPadre);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado", estudiante.Grupo);
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", estudiante.CedulaEstudiante);
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "Profesion", estudiante.CedulaPadre);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado", estudiante.Grupo);
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaEstudiante,GradosCursados,Periodo,CursoActual,EstadoPeriodo,CedulaPadre,Grupo")] Estudiante estudiante)
        {
            if (id != estudiante.CedulaEstudiante)
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
                    if (!EstudianteExists(estudiante.CedulaEstudiante))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", estudiante.CedulaEstudiante);
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "Profesion", estudiante.CedulaPadre);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado", estudiante.Grupo);
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
                .Include(e => e.CedulaEstudianteNavigation)
                .Include(e => e.CedulaPadreNavigation)
                .Include(e => e.GrupoNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
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
            return _context.Estudiantes.Any(e => e.CedulaEstudiante == id);
        }
    }
}
