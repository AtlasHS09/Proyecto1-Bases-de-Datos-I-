using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class AprobadoReprobado
    {
        [Key]
        public String grupoPeriodo { get; set; }
        public int reprobados { get; set; }
        public int aprobados { get; set; }
    }

}
