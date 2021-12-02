using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Ausencia
    {
        [Key]
        public String nombre { get; set; }
        public int cantidad { get; set; }

    }

}
