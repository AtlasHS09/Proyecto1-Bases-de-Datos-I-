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
    public class PeriodoLectivo : Controller
    {
        private readonly matriculaContext _context;

        public PeriodoLectivo(matriculaContext context)
        {
            _context = context;
        }

        // GET: PeriodoLectivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PeriodoLectivos.ToListAsync());
        }

        // GET: PeriodoLectivo/Details?numero=11&ano=2022
        public async Task<IActionResult> Details(int? numero, int? ano)
        {
            if (numero == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .FirstOrDefaultAsync(m => m.NumeroPeriodo == numero && m.Ano == ano);
            if (periodoLectivo == null)
            {
                return NotFound();
            }

            return View(periodoLectivo);
        }


        // GET: PeriodoLectivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeriodoLectivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroPeriodo,Ano,FechaInicio,FechaFinal,EstadoCurso")] PeriodoLectivo periodoLectivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodoLectivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodoLectivo);
        }

        // GET: PeriodoLectivo/Edit/5
        public async Task<IActionResult> Edit(int? numero, int? ano)
        {
            if (numero == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos.FindAsync(numero, ano);
            if (periodoLectivo == null)
            {
                return NotFound();
            }
            return View(periodoLectivo);
        }

        // POST: PeriodoLectivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int numero,int ano, [Bind("NumeroPeriodo,Ano,FechaInicio,FechaFinal,EstadoCurso")] PeriodoLectivo periodoLectivo)
        {
          /*  if (numero != periodoLectivo.)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodoLectivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoLectivoExists(numero, ano))
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
            return View(periodoLectivo);
        }

        // GET: PeriodoLectivo/Delete/5
        public async Task<IActionResult> Remove(int? NumeroPeriodo, int? Ano)
        {
            if (NumeroPeriodo == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .FirstOrDefaultAsync(m => m.NumeroPeriodo == NumeroPeriodo && m.Ano == Ano);
            if (periodoLectivo == null)
            {
                return NotFound();
            }

            return View(periodoLectivo);

        }


        // GET: PeriodoLectivo/Delete/5
        public async Task<IActionResult> DeleteDetails(int? NumeroPeriodo, int? Ano)
        {
            if (NumeroPeriodo == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .FirstOrDefaultAsync(m => m.NumeroPeriodo == NumeroPeriodo && m.Ano == Ano);
            if (periodoLectivo == null)
            {
                return NotFound();
            }

            return View(periodoLectivo);
        }

        // POST: PeriodoLectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? NumeroPeriodo, int? Ano)
        {
            var periodoLectivo = await _context.PeriodoLectivos.FindAsync(NumeroPeriodo, Ano);
            _context.PeriodoLectivos.Remove(periodoLectivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoLectivoExists(int NumeroPeriodo, int Ano)
        {
            return _context.PeriodoLectivos.Any(e => e.NumeroPeriodo == NumeroPeriodo && e.Ano == Ano);
        }
    }
}
