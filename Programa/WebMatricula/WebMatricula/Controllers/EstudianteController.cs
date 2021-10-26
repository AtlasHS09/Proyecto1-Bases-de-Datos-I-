using System;
using Microsoft.AspNetCore.Mvc;
using WebMatricula.Entities;
using WebMatricula.Repository;

namespace WebMatricula.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteData _estudianteData;

        public EstudianteController(IEstudianteData estudianteData)
        {
            _estudianteData = estudianteData;

        }
        [HttpGet]
        public IActionResult list()
        {
            return Ok(_estudianteData.list());
        }


        [HttpPost]
        public IActionResult add([FromBody] Estudiante estudiante)
        {
            return Ok(_estudianteData.add(estudiante));

        }

        public IActionResult get(int cedula)
        {
            return Ok(_estudianteData.get(cedula));
        }


        [HttpDelete]
        public IActionResult delete(int cedula)
        {
            _estudianteData.delete(cedula);
            return Ok();
        }

        [HttpPatch]
        public IActionResult update([FromBody] Estudiante estudiante)
        {
            _estudianteData.update(estudiante);
            return Ok(estudiante);

        }

        /* public IActionResult getEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            using var con = new MySqlConnection("server=192.168.64.2;port=3306;user=username;password=password;database=matridula");
            {
                con.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM estudiante;", con);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Estudiante cliente = new Estudiante();
                   // Estudiante.Cedula = Convert.ToInt32(reader["cedula"]);
                   // Estudiante.Nombre = reader["Nombre"].ToString();
                  //  Estudiante.Apellido1 = reader["Apellido1"].ToString();
                    
                    estudiantes.Add(Estudiante);

                }
                reader.Close();
            }
            return Ok(con);
        }*/


    }
}