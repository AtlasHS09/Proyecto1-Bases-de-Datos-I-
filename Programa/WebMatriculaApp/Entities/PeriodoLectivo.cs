using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class PeriodoLectivo
    {
        public PeriodoLectivo()
        {
            Grupos = new HashSet<Grupo>();
            Matriculas = new HashSet<Matricula>();
        }

        public int IdPeriodo { get; set; }
        public int Periodo { get; set; }
        public int Anno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
