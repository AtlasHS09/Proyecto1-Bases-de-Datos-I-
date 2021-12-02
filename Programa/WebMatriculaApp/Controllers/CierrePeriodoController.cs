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
    public class CierrePeriodoController : Controller
    {
        private readonly matricula4Context _context;

        public CierrePeriodoController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(int? id)
        {
            string sql = "CALL cierrePeriodo(1)";
            //SqlParameter param1 = new SqlParameter("@p0","value");
            //SqlParameter param2 = new SqlParameter("@p1","value");
            var createdPath = _context.PeriodoLectivos.FromSqlRaw(sql).ToList();

            // _context.CierrePeriodos.FromSqlRaw<CierrePeriodo>(sql);
            return View();
        }
    }
}
