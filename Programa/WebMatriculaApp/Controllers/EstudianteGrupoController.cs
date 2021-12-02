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
    public class EstudianteGrupoController : Controller
    {
        private readonly matricula4Context _context;

        public EstudianteGrupoController(matricula4Context context)
        {
            _context = context;
        }

        // GET: EstudianteGrupo
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.EstudianteGrupos.Include(e => e.IdEstudianteNavigation).Include(e => e.IdGrupoNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: EstudianteGrupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteGrupo = await _context.EstudianteGrupos
                .Include(e => e.IdEstudianteNavigation)
                .Include(e => e.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudianteGrupo == null)
            {
                return NotFound();
            }

            return View(estudianteGrupo);
        }

        // GET: EstudianteGrupo/Create
        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula");
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "Estado");
            return View();
        }

        // POST: EstudianteGrupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,IdGrupo")] EstudianteGrupo estudianteGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", estudianteGrupo.IdEstudiante);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "Estado", estudianteGrupo.IdGrupo);
            return View(estudianteGrupo);
        }

        // GET: EstudianteGrupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteGrupo = await _context.EstudianteGrupos.FindAsync(id);
            if (estudianteGrupo == null)
            {
                return NotFound();
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", estudianteGrupo.IdEstudiante);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "Estado", estudianteGrupo.IdGrupo);
            return View(estudianteGrupo);
        }

        // POST: EstudianteGrupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,IdGrupo")] EstudianteGrupo estudianteGrupo)
        {
            if (id != estudianteGrupo.IdEstudiante)
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
                    if (!EstudianteGrupoExists(estudianteGrupo.IdEstudiante))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", estudianteGrupo.IdEstudiante);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "Estado", estudianteGrupo.IdGrupo);
            return View(estudianteGrupo);
        }

        // GET: EstudianteGrupo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteGrupo = await _context.EstudianteGrupos
                .Include(e => e.IdEstudianteNavigation)
                .Include(e => e.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudianteGrupo == null)
            {
                return NotFound();
            }

            return View(estudianteGrupo);
        }

        // POST: EstudianteGrupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteGrupo = await _context.EstudianteGrupos.FindAsync(id);
            _context.EstudianteGrupos.Remove(estudianteGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteGrupoExists(int id)
        {
            return _context.EstudianteGrupos.Any(e => e.IdEstudiante == id);
        }
    }
}
