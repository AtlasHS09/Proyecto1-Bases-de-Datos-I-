using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class GrupoAprobacion
    {
        [Key]
        public String grupoperiodo { get; set; }
        public int porcentaje { get; set; }
        public String NombreCompleto { get; set; }
        public String nombreMateria { get; set; }

    }

}
