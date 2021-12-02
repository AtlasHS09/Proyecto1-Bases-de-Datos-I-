using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class InasistenciaEstudiante
    {
        public int IdInasistenciaE { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
    }
}
