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
    public class PorcentajeGeneroController : Controller
    {
        private readonly matriculaContext _context;

        public PorcentajeGeneroController(matriculaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Grafico()
        {
           // var list = new List<PopulationModel>();
           // list.Add(new PopulationModel { CityName = "Chennai", PopulationYear2020 = 28000 });

            List<PorcentajeGenero> list;
            string sql = "CALL porcentajeGenero";
            list = _context.PorcentajeGeneros.FromSqlRaw<PorcentajeGenero>(sql).ToList();

            return Json(list);

        }
    }
}
