using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Notum
    {
        public int CodigoEvaluacion { get; set; }
        public int CedulaEstudiante { get; set; }
        public int Resultado { get; set; }

        public virtual Estudiante CedulaEstudianteNavigation { get; set; }
        public virtual Evaluacion CodigoEvaluacionNavigation { get; set; }
    }
}
