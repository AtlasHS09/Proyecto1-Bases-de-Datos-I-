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
    public class ProfesorController : Controller
    {
        private readonly matriculaContext _context;

        public ProfesorController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Profesor
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Profesors.Include(p => p.CedulaProfesorNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Profesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .Include(p => p.CedulaProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CedulaProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesor/Create
        public IActionResult Create()
        {
            ViewData["CedulaProfesor"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto");
            ViewData["MateriaImpartida"] = new SelectList(_context.MateriaGrados, "NombreMateria", "NombreMateria");
            return View();
        }

        // POST: Profesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaProfesor,MateriaImpartida,Salario")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", profesor.CedulaProfesor);
            ViewData["MateriaImpartida"] = new SelectList(_context.MateriaGrados, "NombreMateria", "NombreMateria", profesor.MateriaImpartida);
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", profesor.CedulaProfesor);
            ViewData["MateriaImpartida"] = new SelectList(_context.MateriaGrados, "NombreMateria", "NombreMateria", profesor.MateriaImpartida);
            return View(profesor);
        }

        // POST: Profesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaProfesor,MateriaImpartida,Salario")] Profesor profesor)
        {
            if (id != profesor.CedulaProfesor)
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
                    if (!ProfesorExists(profesor.CedulaProfesor))
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", profesor.CedulaProfesor);
            ViewData["MateriaImpartida"] = new SelectList(_context.MateriaGrados, "NombreMateria", "NombreMateria", profesor.MateriaImpartida);
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
                .Include(p => p.CedulaProfesorNavigation)
                .FirstOrDefaultAsync(m => m.CedulaProfesor == id);
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
            return _context.Profesors.Any(e => e.CedulaProfesor == id);
        }
    }
}