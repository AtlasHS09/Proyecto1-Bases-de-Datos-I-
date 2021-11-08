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

    public class EstudianteGrupoController : Controller
    {
        private readonly matriculaContext _context;

        public EstudianteGrupoController(matriculaContext context)
        {
            _context = context;
        }

        // GET: EstudianteGrupo
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.EstudianteGrupos.Include(e => e.CedulaEstudianteNavigation).Include(e => e.GrupoNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: EstudianteGrupo/Details/5
        public async Task<IActionResult> Details(int? CedulaEstudiante, int? Grupo)
        {
            if (CedulaEstudiante == null)
            {
                return NotFound();
            }

            var estudianteGrupo = await _context.EstudianteGrupos
                .Include(e => e.CedulaEstudianteNavigation)
                .Include(e => e.GrupoNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == CedulaEstudiante && m.Grupo == Grupo);
            if (estudianteGrupo == null)
            {
                return NotFound();
            }

            return View(estudianteGrupo);
        }

        // GET: EstudianteGrupo/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto");
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "CodigoGrupo");
            return View();
        }

        // POST: EstudianteGrupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,Grupo")] EstudianteGrupo estudianteGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", estudianteGrupo.CedulaEstudiante);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "CodigoGrupo", estudianteGrupo.Grupo);
            return View(estudianteGrupo);
        }

        // GET: EstudianteGrupo/Edit/5
        public async Task<IActionResult> Edit(int? CedulaEstudiante, int? Grupo)
        {
            if (CedulaEstudiante == null)
            {
                return NotFound();
            }

            var estudianteGrupo = await _context.EstudianteGrupos.FindAsync(CedulaEstudiante, Grupo);
            if (estudianteGrupo == null)
            {
                return NotFound();
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", estudianteGrupo.CedulaEstudiante);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "CodigoGrupo", estudianteGrupo.Grupo);
            return View(estudianteGrupo);
        }

        // POST: EstudianteGrupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? CedulaEstudiante, int? Grupo, [Bind("CedulaEstudiante,Grupo")] EstudianteGrupo estudianteGrupo)
        {
            if (CedulaEstudiante != estudianteGrupo.CedulaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteGrupoExists(estudianteGrupo.CedulaEstudiante, estudianteGrupo.Grupo))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", estudianteGrupo.CedulaEstudiante);
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "CodigoGrupo", estudianteGrupo.Grupo);
            return View(estudianteGrupo);
        }

        // GET: EstudianteGrupo/Delete/5
        public async Task<IActionResult> Delete(int? CedulaEstudiante, int? Grupo)
        {
            if (CedulaEstudiante == null)
            {
                return NotFound();
            }

            var estudianteGrupo = await _context.EstudianteGrupos
                .Include(e => e.CedulaEstudianteNavigation)
                .Include(e => e.GrupoNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == CedulaEstudiante && m.Grupo == Grupo);
            if (estudianteGrupo == null)
            {
                return NotFound();
            }

            return View(estudianteGrupo);
        }

        // POST: EstudianteGrupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CedulaEstudiante, int? Grupo)
        {
            var estudianteGrupo = await _context.EstudianteGrupos.FindAsync(CedulaEstudiante, Grupo);
            _context.EstudianteGrupos.Remove(estudianteGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteGrupoExists(int? CedulaEstudiante, int? Grupo)
        {
            return _context.EstudianteGrupos.Any(e => e.CedulaEstudiante == CedulaEstudiante && e.Grupo == Grupo);
        }
    }
}
