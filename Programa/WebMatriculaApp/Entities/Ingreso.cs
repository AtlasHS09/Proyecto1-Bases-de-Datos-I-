using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Ingreso
    {
        [Key]
        public double ingreso { get; set; }
        public String grupoPeriodo { get; set; }
    }

}
