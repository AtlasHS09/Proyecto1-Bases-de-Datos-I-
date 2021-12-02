using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            CobroFacturas = new HashSet<CobroFactura>();
        }

        public int IdMatricula { get; set; }
        public int IdEstudiante { get; set; }
        public int Periodo { get; set; }
        public int CobrosPendientes { get; set; }
        public decimal MontoMatricula { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual PeriodoLectivo PeriodoNavigation { get; set; }
        public virtual ICollection<CobroFactura> CobroFacturas { get; set; }
    }
}
