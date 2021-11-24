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
    public class EvaluacionController : Controller
    {
        private readonly matriculaContext _context;

        public EvaluacionController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Evaluacion
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Evaluacions.Include(e => e.GrupoNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Evaluacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacions
                .Include(e => e.GrupoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEvaluacion == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // GET: Evaluacion/Create
        public IActionResult Create()
        {
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado");
            return View();
        }

        // POST: Evaluacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEvaluacion,Evaluacion1,Porcentaje,Grupo")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado", evaluacion.Grupo);
            return View(evaluacion);
        }

        // GET: Evaluacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacions.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado", evaluacion.Grupo);
            return View(evaluacion);
        }

        // POST: Evaluacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEvaluacion,Evaluacion1,Porcentaje,Grupo")] Evaluacion evaluacion)
        {
            if (id != evaluacion.CodigoEvaluacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionExists(evaluacion.CodigoEvaluacion))
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
            ViewData["Grupo"] = new SelectList(_context.Grupos, "CodigoGrupo", "Estado", evaluacion.Grupo);
            return View(evaluacion);
        }

        // GET: Evaluacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacions
                .Include(e => e.GrupoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEvaluacion == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // POST: Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacion = await _context.Evaluacions.FindAsync(id);
            _context.Evaluacions.Remove(evaluacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluacions.Any(e => e.CodigoEvaluacion == id);
        }
    }
}
