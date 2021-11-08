using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Nota = new HashSet<Notum>();
        }

        public int CedulaEstudiante { get; set; }
        public int GradosCursados { get; set; }
        public int Periodo { get; set; }
        public string CursoActual { get; set; }
        public string EstadoPeriodo { get; set; }
        public int CedulaPadre { get; set; }

        public virtual Usuario CedulaEstudianteNavigation { get; set; }
        public virtual Padre CedulaPadreNavigation { get; set; }
        public virtual AsistenciaEstudiante AsistenciaEstudiante { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
