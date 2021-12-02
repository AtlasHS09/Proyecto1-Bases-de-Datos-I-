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
    public class AprobacionController : Controller
    {
        private readonly matricula4Context _context;

        public AprobacionController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Aprobacion> list;
            string sql = "CALL promedioAprobacionXgrupo";
            list = _context.Aprobacions.FromSqlRaw<Aprobacion>(sql).ToList();

            return View(list);
        }
    }
}
