using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class InasistenciaEstudiante
    {
        public int CedulaEstudiante { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Estudiante CedulaEstudianteNavigation { get; set; }
    }
}
