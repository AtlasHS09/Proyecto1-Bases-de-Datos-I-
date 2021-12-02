using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMatriculaApp.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMatriculaApp.Controllers
{
    public class GrupoAprobacionController : Controller
    {
        private readonly matricula4Context _context;

        public GrupoAprobacionController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<GrupoAprobacion> list;
            string sql = "CALL top15GrupoPorcentajeAprobacion";
            list = _context.GrupoAprobacions.FromSqlRaw<GrupoAprobacion>(sql).ToList();

            return View(list);
        }
    }
}
