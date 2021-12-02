using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class CobroFactura
    {
        public int IdCobroFactura { get; set; }
        public int IdMatricula { get; set; }
        public int NumeroMensualidad { get; set; }
        public int IdPadre { get; set; }
        public double Cantidad { get; set; }
        public DateTime FechaCobro { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Estado { get; set; }

        public virtual Matricula IdMatriculaNavigation { get; set; }
        public virtual Padre IdPadreNavigation { get; set; }
    }
}
