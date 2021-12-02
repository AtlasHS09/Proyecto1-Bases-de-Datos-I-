using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace WebMatriculaApp.Entities
{
    public class GrupoPeriodo
    {
        [Key]
        public String periodo { get; set; }
        public int cantidad { get; set; }

    }

}
