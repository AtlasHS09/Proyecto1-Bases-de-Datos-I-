using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class Ingreso
    {
          [Key]
          public String gpa { get; set; }
          public double porcentaje { get; set; }
     }

}


