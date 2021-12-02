using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Aumento
    {
        [Key]
        public String nombre { get; set; }
        public int monto { get; set; }

    }

}
