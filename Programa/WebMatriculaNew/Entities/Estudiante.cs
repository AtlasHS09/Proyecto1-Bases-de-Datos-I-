using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            InasistenciaEstudiantes = new HashSet<InasistenciaEstudiante>();
            Matriculas = new HashSet<Matricula>();
            Nota = new HashSet<Notum>();
        }

        public int CedulaEstudiante { get; set; }
        public int GradosCursados { get; set; }
        public int Periodo { get; set; }
        public string CursoActual { get; set; }
        public string EstadoPeriodo { get; set; }
        public int CedulaPadre { get; set; }
        public int? Grupo { get; set; }

        public virtual Usuario CedulaEstudianteNavigation { get; set; }
        public virtual Padre CedulaPadreNavigation { get; set; }
        public virtual Grupo GrupoNavigation { get; set; }
        public virtual ICollection<InasistenciaEstudiante> InasistenciaEstudiantes { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
