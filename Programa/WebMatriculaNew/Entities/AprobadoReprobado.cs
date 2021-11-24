using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class AprobadoReprobado
    {
          [Key]
          public String gp { get; set; }
          public int reprobado { get; set; }
          public int aprobado { get; set; }

     }

}


