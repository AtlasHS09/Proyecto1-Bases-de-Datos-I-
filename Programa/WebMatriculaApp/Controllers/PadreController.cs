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
    public class PadreController : Controller
    {
        private readonly matricula4Context _context;

        public PadreController(matricula4Context context)
        {
            _context = context;
        }

        // GET: Padre
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.Padres.Include(p => p.IdPadreNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: Padre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres
                .Include(p => p.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdPadre == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // GET: Padre/Create
        public IActionResult Create()
        {
            ViewData["IdPadre"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula");
            return View();
        }

        // POST: Padre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPadre,Profesion,Conyugue,TelefonoConyugue")] Padre padre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPadre"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", padre.IdPadre);
            return View(padre);
        }

        // GET: Padre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres.FindAsync(id);
            if (padre == null)
            {
                return NotFound();
            }
            ViewData["IdPadre"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", padre.IdPadre);
            return View(padre);
        }

        // POST: Padre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPadre,Profesion,Conyugue,TelefonoConyugue")] Padre padre)
        {
            if (id != padre.IdPadre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadreExists(padre.IdPadre))
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
            ViewData["IdPadre"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", padre.IdPadre);
            return View(padre);
        }

        // GET: Padre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres
                .Include(p => p.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdPadre == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // POST: Padre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padre = await _context.Padres.FindAsync(id);
            _context.Padres.Remove(padre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadreExists(int id)
        {
            return _context.Padres.Any(e => e.IdPadre == id);
        }
    }
}
