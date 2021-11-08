using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Padre
    {
        public Padre()
        {
            Estudiantes = new HashSet<Estudiante>();
         
        }

        public int CedulaPadre { get; set; }
        public string Profesion { get; set; }
        public string Conyugue { get; set; }
        public string TelefonoConyugue { get; set; }
        public decimal CostoMensualidad { get; set; }
        public int PagosRealizados { get; set; }

        public virtual Usuario CedulaPadreNavigation { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
       
    }
}
