using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class AumentoProfesores
    {
          [Key]
          public String cedula { get; set; }
          public int aumento { get; set; }
     }

}


