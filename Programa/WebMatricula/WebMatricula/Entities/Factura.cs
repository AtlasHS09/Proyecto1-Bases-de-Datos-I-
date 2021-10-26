using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Factura
    {
        public int CedulaPadre { get; set; }
        public int Periodo { get; set; }
        public int Ano { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoTotal { get; set; }
        public int CedulaEstudiante { get; set; }

        public virtual Matricula Matricula { get; set; }
    }
}
