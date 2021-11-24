using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMatriculaNew.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMatriculaNew.Controllers
{
    public class CantidadEstudianteController : Controller
    {
        private readonly matriculaContext _context;

        public CantidadEstudianteController(matriculaContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Grafico()
        {
            List<CantidadEstudiante> list;
            string sql = "CALL CantidadEstudiantePeriodoGrupo";
            list = _context.CantidadEstudiantes.FromSqlRaw<CantidadEstudiante>(sql).ToList();

            return Json(list);
       
        }

    }
}