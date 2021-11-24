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
    public class GrupoController : Controller
    {
        private readonly matriculaContext _context;

        public GrupoController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Grupo
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Grupos.Include(g => g.CedulaProfesorNavigation).Include(g => g.MateriaGradoNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Grupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.CedulaProfesorNavigation)
                .Include(g => g.MateriaGradoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupo/Create
        public IActionResult Create()
        {
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida");
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria");
            return View();
        }

        // POST: Grupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoGrupo,Periodo,Cupo,MateriaGrado,NotaMinima,NombreCurso,Anno,Aula,CedulaProfesor,Estado")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", grupo.CedulaProfesor);
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria", grupo.MateriaGrado);
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", grupo.CedulaProfesor);
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria", grupo.MateriaGrado);
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoGrupo,Periodo,Cupo,MateriaGrado,NotaMinima,NombreCurso,Anno,Aula,CedulaProfesor,Estado")] Grupo grupo)
        {
            if (id != grupo.CodigoGrupo)
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
                    if (!GrupoExists(grupo.CodigoGrupo))
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "MateriaImpartida", grupo.CedulaProfesor);
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria", grupo.MateriaGrado);
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
                .Include(g => g.CedulaProfesorNavigation)
                .Include(g => g.MateriaGradoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoGrupo == id);
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
            return _context.Grupos.Any(e => e.CodigoGrupo == id);
        }
    }
}
