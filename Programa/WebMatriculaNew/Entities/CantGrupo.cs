using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class CantGrupo
    {
          [Key]
          public String periodo { get; set; }
          public int cantidad { get; set; }
     }

}


