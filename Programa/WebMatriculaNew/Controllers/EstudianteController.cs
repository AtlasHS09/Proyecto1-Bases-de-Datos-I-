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
    public class EstudianteController : Controller
    {
        private readonly matriculaContext _context;

        public EstudianteController(matriculaContext context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            var matriculaContext = _context.Estudiantes.Include(e => e.CedulaEstudianteNavigation).Include(e => e.CedulaPadreNavigation);
            return View(await matriculaContext.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CedulaEstudianteNavigation)
                .Include(e => e.CedulaPadreNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "Cedula");
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "CedulaPadre");
            ViewData["CursoActual"] = new SelectList(_context.CursoProfesors, "CodigoCurso", "NombreCurso");

            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaEstudiante,GradosCursados,Periodo,CursoActual,EstadoPeriodo,CedulaPadre")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "Cedula");
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "CedulaPadre");
          
            ViewData["CursoActual"] = new SelectList(_context.CursoProfesors, "CodigoCurso", "NombreCurso");
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "Cedula");
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "CedulaPadre");
          
            ViewData["CursoActual"] = new SelectList(_context.CursoProfesors, "CodigoCurso", "NombreCurso");
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CedulaEstudiante,GradosCursados,Periodo,CursoActual,EstadoPeriodo,CedulaPadre")] Estudiante estudiante)
        {
            if (id != estudiante.CedulaEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.CedulaEstudiante))
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

            ViewData["CedulaEstudiante"] = new SelectList(_context.Usuarios, "Cedula", "Cedula");
            ViewData["CedulaPadre"] = new SelectList(_context.Padres, "CedulaPadre", "CedulaPadre");
       
            ViewData["CursoActual"] = new SelectList(_context.CursoProfesors, "CodigoCurso", "NombreCurso");
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CedulaEstudianteNavigation)
                .Include(e => e.CedulaPadreNavigation)
                .FirstOrDefaultAsync(m => m.CedulaEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.CedulaEstudiante == id);
        }

        public async Task<IActionResult> NotaXEvaluacion(int? id)
        {
            List<NotaXEvaluacion> lista = new List<NotaXEvaluacion>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "select ev.evaluacion as evaluacion, ev.porcentaje, n.resultado as resultado from nota as n inner join estudiante as e inner join evaluacion as ev inner join cursoProfesor as c " +
                        " inner join grupo as g where n.cedulaEstudiante = e.cedulaEstudiante and n.codigoEvaluacion = ev.codigoEvaluacion and e.cedulaEstudiante = " + id;

                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new NotaXEvaluacion
                            {
                                Evaluacion = reader.GetString(0),
                                Porcentaje = reader.GetInt32(1),
                                Resultado = reader.GetInt32(2)
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

    

