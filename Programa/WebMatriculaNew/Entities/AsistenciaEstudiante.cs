using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class AsistenciaEstudiante
    {
        public int CedulaEstudiante { get; set; }
        public int? Porcentaje { get; set; }

        public virtual Estudiante CedulaEstudianteNavigation { get; set; }
    }
}
