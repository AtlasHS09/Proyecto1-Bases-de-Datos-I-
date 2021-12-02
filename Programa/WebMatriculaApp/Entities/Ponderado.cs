using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Ponderado
    {
        [Key]
        public int id_estudiante { get; set; }
        public double promedioPonderado { get; set; }
        public int cantidadGrupos { get; set; }
        public int gruposaprobados { get; set; }
        public int promedioGruposA { get; set; }
        public int gruposreprobados { get; set; }
        public int promedioGruposR { get; set; }
    }

}
