using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CedulaEstudiante { get; set; }
        public int PeriodoMatricular { get; set; }
        public int Ano { get; set; }
        public int CobrosPendientes { get; set; }
        public decimal MontoMatricula { get; set; }
  
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
