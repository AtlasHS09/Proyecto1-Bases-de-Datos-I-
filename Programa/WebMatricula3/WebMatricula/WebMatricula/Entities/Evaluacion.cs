using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Evaluacion
    {
        public int CodigoEvaluacion { get; set; }
        public string Evaluacion1 { get; set; }
        public int Porcentaje { get; set; }
        public int? Curso { get; set; }

        public virtual HorarioClase CursoNavigation { get; set; }
    }
}
