using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Notum
    {
        public int IdNota { get; set; }
        public int IdEvaluacion { get; set; }
        public int IdEstudiante { get; set; }
        public int Resultado { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Evaluacion IdEvaluacionNavigation { get; set; }
    }
}
