using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class PeriodoLectivo
    {
        public PeriodoLectivo()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int NumeroPeriodo { get; set; }
        public int Anno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string EstadoCurso { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
