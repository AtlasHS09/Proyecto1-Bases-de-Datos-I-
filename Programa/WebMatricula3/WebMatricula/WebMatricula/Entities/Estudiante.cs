using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            PeriodoLectivos = new HashSet<PeriodoLectivo>();
        }

        public int CedulaEstudiante { get; set; }
        public int GradosCursados { get; set; }
        public int Periodo { get; set; }
        public string CursoActual { get; set; }
        public string EstadoPeriodo { get; set; }
        public int Grupo { get; set; }

        public virtual Usuario CedulaEstudianteNavigation { get; set; }
        public virtual Grupo GrupoNavigation { get; set; }
        public virtual ICollection<PeriodoLectivo> PeriodoLectivos { get; set; }
    }
}
