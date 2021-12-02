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
    public class CantEstudianteController : Controller
    {
        private readonly matricula4Context _context;

        public CantEstudianteController(matricula4Context context)
        {
            _context = context;
        }

// GET: Aumento
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult grafico()
        {

             List<CantEstudiante> list;
             string sql = "CALL cantidadDeEstudiantesXperiodoXgrupo";
            list = _context.CantEstudiantes.FromSqlRaw<CantEstudiante>(sql).ToList();

            return Json(list);
        }

    }
}
