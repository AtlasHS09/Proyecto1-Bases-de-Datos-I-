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
    public class ReprobacionGrupoController : Controller
    {
        private readonly matriculaContext _context;

        public ReprobacionGrupoController(matriculaContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<ReprobacionGrupo> list;
            string sql = "CALL porcentajeReprobacionGrupo";
            list = _context.ReprobacionGrupos.FromSqlRaw<ReprobacionGrupo>(sql).ToList();

            return View(list);        
        }
    }
}