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
    public class GrupoController : Controller
    {
        private readonly matriculaContext _context;

        public GrupoController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Grupo
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Grupos.Include(g => g.CedulaProfesorNavigation).Include(g => g.MateriaGradoNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Grupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.CedulaProfesorNavigation)
                .Include(g => g.MateriaGradoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupo/Create
        public IActionResult Create()
        {
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor");
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria");
            return View();
        }

        // POST: Grupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoGrupo,Periodo,Cupo,MateriaGrado,NotaMinima,CedulaProfesor,Estado")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor", grupo.CedulaProfesor);
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria", grupo.MateriaGrado);
            return View(grupo);
        }

        // GET: Grupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor", grupo.CedulaProfesor);
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria", grupo.MateriaGrado);
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoGrupo,Periodo,Cupo,MateriaGrado,NotaMinima,CedulaProfesor,Estado")] Grupo grupo)
        {
            if (id != grupo.CodigoGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.CodigoGrupo))
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
            ViewData["CedulaProfesor"] = new SelectList(_context.Profesors, "CedulaProfesor", "CedulaProfesor", grupo.CedulaProfesor);
            ViewData["MateriaGrado"] = new SelectList(_context.MateriaGrados, "CodigoMateriaGrado", "NombreMateria", grupo.MateriaGrado);
            return View(grupo);
        }

        // GET: Grupo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.CedulaProfesorNavigation)
                .Include(g => g.MateriaGradoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.CodigoGrupo == id);
        }
    


    public async Task<IActionResult> AsistenciaXGrupo(int? id)
        {
            List<AsistenciaXGrupo> lista = new List<AsistenciaXGrupo>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "Select g.codigoGrupo as codigoGrupo, e.cedulaEstudiante as cedulaEstudiante, a.porcentaje as porcentaje  from estudiante as e " +
                        " inner join grupo as g  inner join asistenciaEstudiante as a where e.grupo = g.codigoGrupo and " +
                        " e.cedulaEstudiante = a.cedulaEstudiante and g.codigoGrupo = " + id;

                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new AsistenciaXGrupo
                            {
                                CodigoGrupo = reader.GetInt32(0),
                                CedulaEstudiante = reader.GetInt32(1),
                                Porcentaje = reader.GetInt32(2)
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

        public async Task<IActionResult> NotaXEvaluacionXGrupo(int? id)
        {
            List<NotaXEvaluacionXGrupo> lista = new List<NotaXEvaluacionXGrupo>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "select ev.evaluacion as evaluacion, ev.porcentaje, e.cedulaEstudiante as cedulaEstudiante, n.resultado as resultado from nota as n inner join estudiante as e inner join evaluacion as ev inner join cursoProfesor as c " +
                        " inner join grupo as g where n.cedulaEstudiante = e.cedulaEstudiante and n.codigoEvaluacion = ev.codigoEvaluacion and ev.curso = c.CodigoCurso and c.profesor = g.cedulaProfesor and g.codigoGrupo = " + id;

                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new NotaXEvaluacionXGrupo
                            {
                                Evaluacion = reader.GetString(0),
                                Porcentaje = reader.GetInt32(1),
                                CedulaEstudiante = reader.GetInt32(2),
                                Resultado = reader.GetInt32(3)
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
