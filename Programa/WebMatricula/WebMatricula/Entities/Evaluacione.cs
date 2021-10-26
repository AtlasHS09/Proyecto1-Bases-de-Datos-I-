using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Evaluacione
    {
        public string Evaluacion { get; set; }
        public int Porcentaje { get; set; }
        public int? Curso { get; set; }

        public virtual HorarioClase CursoNavigation { get; set; }
    }
}
