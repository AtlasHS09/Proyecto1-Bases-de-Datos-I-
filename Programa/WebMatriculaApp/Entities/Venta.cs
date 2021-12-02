using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class Venta
    {
        [Key]
        public String periodo { get; set; }
        public double cobros { get; set; }

    }

}
