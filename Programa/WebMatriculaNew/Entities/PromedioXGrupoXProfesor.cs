using System;
using System.ComponentModel.DataAnnotations;


namespace WebMatriculaNew.Entities
{
    public class PromedioXGrupoXProfesor
    {
        [Key]
        public String gp { get; set; }
        public double promedio { get; set; }

    }

}