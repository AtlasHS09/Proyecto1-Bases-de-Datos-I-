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
    public class GrupoController : Controller
    {
        private readonly matricula4Context _context;

        public GrupoController(matricula4Context context)
        {
            _context = context;
        }

        // GET: Grupo
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.Grupos.Include(g => g.IdMateriaGradoNavigation).Include(g => g.IdProfesorNavigation).Include(g => g.PeriodoNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: Grupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdMateriaGradoNavigation)
                .Include(g => g.IdProfesorNavigation)
                .Include(g => g.PeriodoNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupo/Create
        public IActionResult Create()
        {
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria");
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor");
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo");
            return View();
        }

        // POST: Grupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,Periodo,Cupo,IdMateriaGrado,NotaMinima,Aula,Estado,IdProfesor")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria", grupo.IdMateriaGrado);
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", grupo.IdProfesor);
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo", grupo.Periodo);
            return View(grupo);
        }

        // GET: Grupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria", grupo.IdMateriaGrado);
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", grupo.IdProfesor);
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo", grupo.Periodo);
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,Periodo,Cupo,IdMateriaGrado,NotaMinima,Aula,Estado,IdProfesor")] Grupo grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.IdGrupo))
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
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria", grupo.IdMateriaGrado);
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", grupo.IdProfesor);
            ViewData["Periodo"] = new SelectList(_context.PeriodoLectivos, "IdPeriodo", "IdPeriodo", grupo.Periodo);
            return View(grupo);
        }

        // GET: Grupo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdMateriaGradoNavigation)
                .Include(g => g.IdProfesorNavigation)
                .Include(g => g.PeriodoNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.IdGrupo == id);
        }
        public IActionResult Aprobado(int? id)
        {
            List<Aprobacion> list;
            string sql = "CALL promedioAprobacionXgrupoParticular(" + id + ")";
            list = _context.Aprobacions.FromSqlRaw<Aprobacion>(sql).ToList();

            return View(list);
        }
    }
}
