using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Cobro
    {
        public int CedulaEstudiante { get; set; }
        public int Periodo { get; set; }
        public int MensualidadesPagadas { get; set; }
        public decimal CantidadIngresada { get; set; }
        public DateTime Fecha { get; set; }
        public int Anno { get; set; }

        public virtual Matricula Matricula { get; set; }
    }
}
