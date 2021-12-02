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
    public class ProfesorController : Controller
    {
        private readonly matricula4Context _context;

        public ProfesorController(matricula4Context context)
        {
            _context = context;
        }

        // GET: Profesor
        public async Task<IActionResult> Index()
        {
            var matricula4Context = _context.Profesors.Include(p => p.IdMateriaGradoNavigation).Include(p => p.IdProfesorNavigation);
            return View(await matricula4Context.ToListAsync());
        }

        // GET: Profesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .Include(p => p.IdMateriaGradoNavigation)
                .Include(p => p.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesor/Create
        public IActionResult Create()
        {
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria");
            ViewData["IdProfesor"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula");
            return View();
        }

        // POST: Profesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,IdMateriaGrado,Salario")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria", profesor.IdMateriaGrado);
            ViewData["IdProfesor"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", profesor.IdProfesor);
            return View(profesor);
        }

        // GET: Profesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria", profesor.IdMateriaGrado);
            ViewData["IdProfesor"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", profesor.IdProfesor);
            return View(profesor);
        }

        // POST: Profesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,IdMateriaGrado,Salario")] Profesor profesor)
        {
            if (id != profesor.IdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.IdProfesor))
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
            ViewData["IdMateriaGrado"] = new SelectList(_context.MateriaGrados, "IdMateriaGrado", "NombreMateria", profesor.IdMateriaGrado);
            ViewData["IdProfesor"] = new SelectList(_context.Usuarios, "IdUsuario", "Cedula", profesor.IdProfesor);
            return View(profesor);
        }

        // GET: Profesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .Include(p => p.IdMateriaGradoNavigation)
                .Include(p => p.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesors.FindAsync(id);
            _context.Profesors.Remove(profesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesors.Any(e => e.IdProfesor == id);
        }
    }
}
