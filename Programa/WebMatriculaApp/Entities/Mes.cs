using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaApp.Entities
{
    public class Mes
    {
        [Key]
        public String gradoperiodomes { get; set; }
        public double cobros { get; set; }
        public double facturados { get; set; }
    }
}