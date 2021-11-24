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
    public class CobroController : Controller
    {
        private readonly matriculaContext _context;

        public CobroController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Cobro
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Cobros.Include(c => c.Matricula);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Cobro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobros
                .Include(c => c.Matricula)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (cobro == null)
            {
                return NotFound();
            }

            return View(cobro);
        }

        // GET: Cobro/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Matriculas, "CedulaEstudiante", "CedulaEstudiante");
            return View();
        }

        // POST: Cobro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,Periodo,MensualidadesPagadas,CantidadIngresada,Fecha,Anno")] Cobro cobro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Matriculas, "CedulaEstudiante", "CedulaEstudiante", cobro.CedulaEstudiante);
            return View(cobro);
        }

        // GET: Cobro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobros.FindAsync(id);
            if (cobro == null)
            {
                return NotFound();
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Matriculas, "CedulaEstudiante", "CedulaEstudiante", cobro.CedulaEstudiante);
            return View(cobro);
        }

        // POST: Cobro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaEstudiante,Periodo,MensualidadesPagadas,CantidadIngresada,Fecha,Anno")] Cobro cobro)
        {
            if (id != cobro.CedulaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobroExists(cobro.CedulaEstudiante))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Matriculas, "CedulaEstudiante", "CedulaEstudiante", cobro.CedulaEstudiante);
            return View(cobro);
        }

        // GET: Cobro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobros
                .Include(c => c.Matricula)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (cobro == null)
            {
                return NotFound();
            }

            return View(cobro);
        }

        // POST: Cobro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobro = await _context.Cobros.FindAsync(id);
            _context.Cobros.Remove(cobro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobroExists(int id)
        {
            return _context.Cobros.Any(e => e.CedulaEstudiante == id);
        }
    }
}
