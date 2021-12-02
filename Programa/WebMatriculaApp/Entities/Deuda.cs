using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Deuda
    {
        [Key]
        public String padre { get; set; }
        public double cantidad { get; set; }

    }

}
