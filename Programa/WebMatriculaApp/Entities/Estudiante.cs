using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            InasistenciaEstudiantes = new HashSet<InasistenciaEstudiante>();
            Matriculas = new HashSet<Matricula>();
            Nota = new HashSet<Notum>();
        }

        public int IdEstudiante { get; set; }
        public int Periodo { get; set; }
        public int GradoActual { get; set; }
        public int IdPadre { get; set; }

        public virtual Usuario IdEstudianteNavigation { get; set; }
        public virtual Padre IdPadreNavigation { get; set; }
        public virtual ICollection<InasistenciaEstudiante> InasistenciaEstudiantes { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
