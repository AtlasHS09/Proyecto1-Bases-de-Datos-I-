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
    public class VentaController : Controller
    {
        private readonly matricula4Context _context;

        public VentaController(matricula4Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Venta> list;
            string sql = "CALL ventasXperiodo";
            list = _context.Ventas.FromSqlRaw<Venta>(sql).ToList();
            return View(list);
        }
    }
}
