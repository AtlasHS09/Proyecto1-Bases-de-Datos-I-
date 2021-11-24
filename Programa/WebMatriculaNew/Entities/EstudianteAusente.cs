using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class EstudianteAusente
    {
          [Key]
          public String nombreCompleto { get; set; }
          public int cantidad { get; set; }
     }

}


