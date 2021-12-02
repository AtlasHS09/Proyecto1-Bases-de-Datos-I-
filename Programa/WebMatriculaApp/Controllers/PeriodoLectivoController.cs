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
    public class PeriodoLectivoController : Controller
    {
        private readonly matricula4Context _context;
        private int _param;


        public PeriodoLectivoController(matricula4Context context)
        {
            _context = context;
        }

        // GET: PeriodoLectivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PeriodoLectivos.ToListAsync());
        }

        // GET: PeriodoLectivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
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
        public async Task<IActionResult> Create([Bind("IdPeriodo,Periodo,Anno,FechaInicio,FechaFinal,Estado")] PeriodoLectivo periodoLectivo)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,Periodo,Anno,FechaInicio,FechaFinal,Estado")] PeriodoLectivo periodoLectivo)
        {
            if (id != periodoLectivo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodoLectivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoLectivoExists(periodoLectivo.IdPeriodo))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodoLectivo = await _context.PeriodoLectivos
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (periodoLectivo == null)
            {
                return NotFound();
            }

            return View(periodoLectivo);
        }

        // POST: PeriodoLectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periodoLectivo = await _context.PeriodoLectivos.FindAsync(id);
            _context.PeriodoLectivos.Remove(periodoLectivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoLectivoExists(int id)
        {
            return _context.PeriodoLectivos.Any(e => e.IdPeriodo == id);
        }
        public IActionResult Reprobado(int? id)
        {
            List<Reprobacion> list;
            string sql = "CALL porcentajeReprobacionXGrupoParticular(" + id + ")";
            list = _context.Reprobacions.FromSqlRaw<Reprobacion>(sql).ToList();

            return View(list);
        }
        public async Task<IActionResult> Cierre(int id)
        {
            if (id == null)
            {
                _param = 0;
            }
            _param = id;

           
             string sql = "Call cierrePeriodo(" + _param.ToString() + ")";
             int result;
             using (var connection = _context.Database.GetDbConnection())
             {
                 await connection.OpenAsync();
                 using (var command = connection.CreateCommand())
                 {
                     command.CommandText = sql;
                     result = await command.ExecuteNonQueryAsync();
                 }
             }
             string message = "Cierre del Periodo : " + _param + "";
             ViewBag.Message = message;

             string filas = (result*-1).ToString() + " Filas afectadas";

            ViewBag.Filas = filas;

            return View();
        }
    }
}
