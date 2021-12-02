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
    public class MateriaGradoController : Controller
    {
        private readonly matricula4Context _context;

        public MateriaGradoController(matricula4Context context)
        {
            _context = context;
        }

        // GET: MateriaGrado
        public async Task<IActionResult> Index()
        {
            return View(await _context.MateriaGrados.ToListAsync());
        }

        // GET: MateriaGrado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaGrado = await _context.MateriaGrados
                .FirstOrDefaultAsync(m => m.IdMateriaGrado == id);
            if (materiaGrado == null)
            {
                return NotFound();
            }

            return View(materiaGrado);
        }

        // GET: MateriaGrado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriaGrado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMateriaGrado,NombreMateria,Grado")] MateriaGrado materiaGrado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaGrado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaGrado);
        }

        // GET: MateriaGrado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaGrado = await _context.MateriaGrados.FindAsync(id);
            if (materiaGrado == null)
            {
                return NotFound();
            }
            return View(materiaGrado);
        }

        // POST: MateriaGrado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMateriaGrado,NombreMateria,Grado")] MateriaGrado materiaGrado)
        {
            if (id != materiaGrado.IdMateriaGrado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaGrado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaGradoExists(materiaGrado.IdMateriaGrado))
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
            return View(materiaGrado);
        }

        // GET: MateriaGrado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaGrado = await _context.MateriaGrados
                .FirstOrDefaultAsync(m => m.IdMateriaGrado == id);
            if (materiaGrado == null)
            {
                return NotFound();
            }

            return View(materiaGrado);
        }

        // POST: MateriaGrado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaGrado = await _context.MateriaGrados.FindAsync(id);
            _context.MateriaGrados.Remove(materiaGrado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaGradoExists(int id)
        {
            return _context.MateriaGrados.Any(e => e.IdMateriaGrado == id);
        }
    }
}
