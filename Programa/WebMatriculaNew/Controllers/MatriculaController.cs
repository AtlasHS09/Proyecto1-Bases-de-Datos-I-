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

    public class MatriculaController : Controller
    {
        private readonly matriculaContext _context;

        public MatriculaController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matriculas.ToListAsync());
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? CedulaEstudiante, int? PeriodoMatricular, int? Ano)
        {
            if (CedulaEstudiante == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == CedulaEstudiante && m.PeriodoMatricular == PeriodoMatricular && m.Ano == Ano);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CedulaEstudiante");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,PeriodoMatricular,Ano,CobrosPendientes,MontoMatricula")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                // Buscar los grupos del Grado del Estudiante

                List<EstudianteGrupo> lista = new List<EstudianteGrupo>();
                var conn = _context.Database.GetDbConnection();
                try
                {
                    await conn.OpenAsync();
                    using (var command = conn.CreateCommand())
                    {
                        string query = "Select g.codigoGrupo as codigoGrupo from grupo as g inner join materiaGrado as mg on g.materiaGrado = mg.codigoMateriaGrado "+
                                        " inner join estudiante as e on mg.grado = e.gradosCursados where e.cedulaEstudiante = " + matricula.CedulaEstudiante;

                        command.CommandText = query;
                        DbDataReader reader = await command.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                           // var SqlCommand command2;
                           // var SqlDataAdapter adapter = new SqlDataAdapter();
                           // String sql = "";
                            while (await reader.ReadAsync())
                            { 
                                var eg = new EstudianteGrupo
                                {
                                    CedulaEstudiante = matricula.CedulaEstudiante,
                                    Grupo = reader.GetInt32(0)
                                 
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

                foreach (EstudianteGrupo eg in lista)
                {
                    _context.Add(eg);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CedulaEstudiante", matricula.CedulaEstudiante);

            return View(matricula);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? CedulaEstudiante, int? PeriodoMatricular, int? Ano)
        {
            if (CedulaEstudiante == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(CedulaEstudiante, PeriodoMatricular,Ano);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CedulaEstudiante", matricula.CedulaEstudiante);


            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? CedulaEstudiante, int? PeriodoMatricular, int? Ano, [Bind("CedulaEstudiante,PeriodoMatricular,Ano,CobrosPendientes,MontoMatricula")] Matricula matricula)
        {
            if (CedulaEstudiante != matricula.CedulaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.CedulaEstudiante, matricula.PeriodoMatricular, matricula.Ano))
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
            ViewData["CedulaEstudiante"] = new SelectList(_context.Estudiantes, "CedulaEstudiante", "CedulaEstudiante", matricula.CedulaEstudiante);

            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? CedulaEstudiante, int? PeriodoMatricular, int? Ano)
        {
            if (CedulaEstudiante == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == CedulaEstudiante && m.PeriodoMatricular == PeriodoMatricular && m.Ano == Ano);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CedulaEstudiante, int? PeriodoMatricular, int? Ano)
        {
            var matricula = await _context.Matriculas.FindAsync(CedulaEstudiante, PeriodoMatricular, Ano);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int? CedulaEstudiante, int? PeriodoMatricular, int? Ano)
        {
            return _context.Matriculas.Any(e => e.CedulaEstudiante == CedulaEstudiante && e.PeriodoMatricular == PeriodoMatricular && e.Ano == Ano);
        }
    
        public async Task<IActionResult> ComprobanteMatricula(int? CedulaEstudiante)
        {
            List<ComprobanteMatricula> lista = new List<ComprobanteMatricula>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "Select eg.cedulaEstudiante as cedulaEstudiante, g.codigoGrupo as codigoGrupo, " +
                        " mg.nombreMateria as  nombreMateria, g.cedulaProfesor as cedulaProfesor from grupo as g inner join estudiante as e " +
                        " inner join estudianteGrupo eg inner join materiaGrado mg on g.materiaGrado = mg.codigoMateriaGrado "+
                        " where e.cedulaEstudiante = eg.cedulaEstudiante and g.codigoGrupo = eg.grupo and eg.CedulaEstudiante = " + CedulaEstudiante;

                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new ComprobanteMatricula
                            {
                                CedulaEstudiante = reader.GetInt32(0),
                                CodigoGrupo = reader.GetInt32(1),
                                NombreMateria = reader.GetString(2),
                                CedulaProfesor = reader.GetInt32(3)
                            };
                            lista.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return View(lista);
        }
    }
}
