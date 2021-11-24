using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class CobroFacturado
    {
          [Key]
          public String gradoperiodo { get; set; }
          public int cobros { get; set; }
          public int facturados { get; set; }

     }

}


