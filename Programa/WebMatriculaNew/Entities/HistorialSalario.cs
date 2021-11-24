using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class HistorialSalario
    {
        public int CedulaProfesor { get; set; }
        public int Salario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Profesor CedulaProfesorNavigation { get; set; }
    }
}
