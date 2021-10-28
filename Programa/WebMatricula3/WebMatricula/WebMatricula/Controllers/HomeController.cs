using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using WebMatricula.Models;

namespace WebCRUDDemo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public IActionResult getClientes()
         {
             List<Cliente> clientes = new List<Cliente>();
             using var con = new MySqlConnection("server=192.168.64.2;port=3306;user=username;password=password;database=tallerMecanico");
             {
                 con.OpenAsync();

                 using var cmd = new MySqlCommand("SELECT * FROM cliente;", con);
                 using var reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     Cliente cliente = new Cliente();
                     cliente.Cedula = Convert.ToInt32(reader["cedula"]);
                     cliente.Nombre = reader["Nombre"].ToString();
                     cliente.Apellido1 = reader["Apellido1"].ToString();
                     cliente.Apellido2 = reader["Apellido2"].ToString();
                     cliente.Direccion = reader["Direccion"].ToString();
                     clientes.Add(cliente);

                 }
                 reader.Close();
             }
             return Ok(con);
         }*/
    }
}
