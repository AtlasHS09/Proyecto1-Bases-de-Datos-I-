using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class CobroVSFactura
    {
        [Key]
        public String gradoperiodo { get; set; }
        public double cobros { get; set; }
        public double facturados { get; set; }
    }

}
