using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class HistorialSalario
    {
        public int IdProfesor { get; set; }
        public int Salario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
