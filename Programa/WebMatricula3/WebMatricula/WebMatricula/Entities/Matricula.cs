using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
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
        public string ProfesionPadre { get; set; }
        public int? CedulaPadre { get; set; }

        public virtual Padre CedulaPadreNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
