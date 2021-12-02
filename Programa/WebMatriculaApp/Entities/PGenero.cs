using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class PGenero
    {
        [Key]
        public String generoPerido { get; set; }
        public int porcentaje { get; set; }
    }

}
