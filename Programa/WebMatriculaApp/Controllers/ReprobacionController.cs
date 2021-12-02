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
    public class ReprobacionController : Controller
    {
        private readonly matricula4Context _context;

        public ReprobacionController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Reprobacion> list;
            string sql = "CALL porcentajeReprobacionXGrupo";
            list = _context.Reprobacions.FromSqlRaw<Reprobacion>(sql).ToList();

            return View(list);
        }
    }
}
