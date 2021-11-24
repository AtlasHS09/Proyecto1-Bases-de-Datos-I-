using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class Top15Grupo
    {
          [Key]
          public int grupo { get; set; }
          public int periodo { get; set; }
          public int porcentaje { get; set; }
          public String nombreCompleto { get; set; }
          public String nombreMateria { get; set; }
     }

}


