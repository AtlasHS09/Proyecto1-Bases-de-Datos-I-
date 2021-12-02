using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class AusenciaParticular
    {
        [Key]
        public int id_estudiante { get; set; }
        public String nombre { get; set; }
        public int cantidad { get; set; }

    }

}
