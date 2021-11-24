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
    public class Top15GrupoController : Controller
    {
        private readonly matriculaContext _context;

        public Top15GrupoController(matriculaContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Top15Grupo> list;
            string sql = "CALL top15GrupoPorcentajeAprobacion";
            list = _context.Top15Grupos.FromSqlRaw<Top15Grupo>(sql).ToList();

            return View(list);        
        }
    }
}