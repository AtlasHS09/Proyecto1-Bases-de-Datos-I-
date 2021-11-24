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
    public class MensualidadController : Controller
    {
        private readonly matriculaContext _context;

        public MensualidadController(matriculaContext context)
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

            List<Mensualidad> list;
            string sql = "CALL cobrosVsFacturadosMensualidad";
            list = _context.Mensualidads.FromSqlRaw<Mensualidad>(sql).ToList();

            return Json(list);
       
        }

    }
}