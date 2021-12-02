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
    public class AumentoController : Controller
    {
        private readonly matricula4Context _context;

        public AumentoController(matricula4Context context)
        {
            _context = context;
        }

// GET: Aumento
        public  IActionResult Index()
        {

            List<Aumento> list;
            string sql = "CALL top10ProfesoresAumento";
            list = _context.Aumentos.FromSqlRaw<Aumento>(sql).ToList();

            return View(list);
           
        }

    }
}
