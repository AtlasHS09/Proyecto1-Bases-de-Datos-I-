using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMatriculaNew.Entities;

namespace WebMatriculaNew.Controllers
{
    public class PadreController : Controller
    {
        private readonly matriculaContext _context;

        public PadreController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Padre
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Padres.Include(p => p.CedulaPadreNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Padre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres
                .Include(p => p.CedulaPadreNavigation)
                .FirstOrDefaultAsync(m => m.CedulaPadre == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // GET: Padre/Create
        public IActionResult Create()
        {
            ViewData["CedulaPadre"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto");
            return View();
        }

        // POST: Padre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaPadre,Profesion,Conyugue,TelefonoConyugue,CostoMensualidad,PagosRealizados")] Padre padre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaPadre"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", padre.CedulaPadre);
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
            ViewData["CedulaPadre"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", padre.CedulaPadre);
            return View(padre);
        }


        // POST: Padre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaPadre,Profesion,Conyugue,TelefonoConyugue,CostoMensualidad,PagosRealizados")] Padre padre)
        {
            if (id != padre.CedulaPadre)
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
                    if (!PadreExists(padre.CedulaPadre))
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
            ViewData["CedulaPadre"] = new SelectList(_context.Usuarios, "Cedula", "NombreCompleto", padre.CedulaPadre);
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
                .Include(p => p.CedulaPadreNavigation)
                .FirstOrDefaultAsync(m => m.CedulaPadre == id);
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
            return _context.Padres.Any(e => e.CedulaPadre == id);
        }
        public async Task<IActionResult> GenerarFactura(int id)
        {
            List<Factura> lista = new List<Factura>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                DateTime localDate = DateTime.Now;
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "select e.CedulaEstudiante, m.periodoMatricular, m.ano, m.montoMatricula from matricula as m inner join estudiante as e" +
                    " inner join padre as p where p.CedulaPadre = e.cedulaPadre and e.cedulaEstudiante = m.cedulaEstudiante and e.cedulaPadre = " + id;
                            

                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        /*
                         *  cedulaPadre int NOT NULL CHECK (cedulaPadre > 0),
                            periodo int NOT NULL,
                            ano int NOT NULL,
                            fechaPago date NOT NULL,
                            montoTotal DECIMAL(13, 4) NOT NULL,
                            cedulaEstudiante int NOT NULL,
                         */
                        while (await reader.ReadAsync())
                        {
                            var eg = new Factura
                            {
                                CedulaPadre = id,
                                CedulaEstudiante = reader.GetInt32(0),
                                Periodo = reader.GetInt32(1),
                                Ano = reader.GetInt32(2),
                                MontoTotal = reader.GetInt32(3),
                                FechaPago = localDate

                            };
                            lista.Add(eg);

                        }
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            foreach (Factura eg in lista)
            {
                _context.Add(eg);
                await _context.SaveChangesAsync();
            }

            return View(lista);
        }
    }

}
