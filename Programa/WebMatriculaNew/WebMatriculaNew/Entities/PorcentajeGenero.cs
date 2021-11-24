using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class PorcentajeGenero
    {
        [Key]
        public String genero { get; set; }
        public int porcentaje { get; set; }
    }
}