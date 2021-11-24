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
    public class CantGrupoController : Controller
    {
        private readonly matriculaContext _context;

        public CantGrupoController(matriculaContext context)
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

            List<CantGrupo> list;
            string sql = "CALL cantidadGruposPeriodo";
            list = _context.CantGrupos.FromSqlRaw<CantGrupo>(sql).ToList();

            return Json(list);
       
        }

    }
}