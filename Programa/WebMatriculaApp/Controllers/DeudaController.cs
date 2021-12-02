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
    public class DeudaController : Controller
    {
        private readonly matricula4Context _context;

        public DeudaController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Deuda> list;
            string sql = "CALL top10PadresDeudas";
            list = _context.Deudas.FromSqlRaw<Deuda>(sql).ToList();

            return View(list);
        }
    }
}
