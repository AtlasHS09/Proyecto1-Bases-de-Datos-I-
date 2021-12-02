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
    public class GrupoPeriodoController : Controller
    {
        private readonly matricula4Context _context;

        public GrupoPeriodoController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult grafico()
        {

            List<GrupoPeriodo> list;
            string sql = "CALL cantidadDeGruposXperiodo";
            list = _context.GrupoPeriodos.FromSqlRaw<GrupoPeriodo>(sql).ToList();

             return Json(list);

        }

    }
}
