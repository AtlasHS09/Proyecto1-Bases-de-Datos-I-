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
    public class AumentoProfesoresController : Controller
    {
        private readonly matriculaContext _context;

        public AumentoProfesoresController(matriculaContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CuadroAumentos()
        {
            //var list = _context.AumentoProfesoress
            //            .FromSqlRaw($"aumentoProfesores").ToList();

            List<AumentoProfesores> list;
            string sql = "CALL aumentoProfesores";
            list = _context.AumentoProfesoress.FromSqlRaw<AumentoProfesores>(sql).ToList();

            return Json(list);
       
        }

    }
}