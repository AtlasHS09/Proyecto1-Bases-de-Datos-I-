using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Aprobacion
    {
        [Key]
        public int grupo { get; set; }
        public int periodo { get; set; }
        public int anno { get; set; }
        public int promedioAprobados { get; set; }
        public String NombreCompleto { get; set; }
        public String nombreMateria { get; set; }

    }

}
