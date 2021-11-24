using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Cobros = new HashSet<Cobro>();
            Facturas = new HashSet<Factura>();
        }

        public int CedulaEstudiante { get; set; }
        public int PeriodoMatricular { get; set; }
        public int Anno { get; set; }
        public int CobrosPendientes { get; set; }
        public decimal MontoMatricula { get; set; }

        public virtual Estudiante CedulaEstudianteNavigation { get; set; }
        public virtual PeriodoLectivo PeriodoLectivo { get; set; }
        public virtual ICollection<Cobro> Cobros { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
