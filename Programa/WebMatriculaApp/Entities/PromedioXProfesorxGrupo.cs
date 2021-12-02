using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class PromedioxProfesorXGrupo
    {
        [Key]
        public String profesorGrupo { get; set; }
        public int promedio { get; set; }
    }

}
