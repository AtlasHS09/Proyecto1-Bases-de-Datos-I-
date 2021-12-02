using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class CantEstudiante
    {
        [Key]
        public String periodoGrupo { get; set; }
        public int cantidad { get; set; }

    }

}
