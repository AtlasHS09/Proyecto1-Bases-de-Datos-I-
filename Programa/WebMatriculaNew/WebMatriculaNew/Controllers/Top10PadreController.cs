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
    public class Top10PadreController : Controller
    {
        private readonly matriculaContext _context;

        public Top10PadreController(matriculaContext context)
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

            List<Top10Padre> list;
            string sql = "CALL Top10PadresDeuda";
            list = _context.Top10Padres.FromSqlRaw<Top10Padre>(sql).ToList();

            return Json(list);
       
        }

    }
}