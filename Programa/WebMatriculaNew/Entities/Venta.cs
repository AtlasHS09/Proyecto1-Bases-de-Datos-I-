using System;
using System.ComponentModel.DataAnnotations;

namespace WebMatriculaNew.Entities
{
    public class Venta
    {
        [Key]
        public String gp { get; set; }
        public int cobros { get; set; }
    }
}