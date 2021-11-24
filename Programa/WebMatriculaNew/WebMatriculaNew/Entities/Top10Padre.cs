using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class Top10Padre
    {
          [Key]
          public String padre { get; set; }
          public int deuda { get; set; }
     }

}


