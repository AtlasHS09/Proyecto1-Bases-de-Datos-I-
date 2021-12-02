using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMatriculaApp.Entities;

namespace WebMatriculaApp.Controllers
{
    public class MesController : Controller
    {
        private readonly matricula4Context _context;

        public MesController(matricula4Context context)
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

             List<Mes> list;
             string sql = "CALL cobrosVsFacturadosMensualidad";
            list = _context.Mess.FromSqlRaw<Mes>(sql).ToList();

            return Json(list);
        }

    }
}