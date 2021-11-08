using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Evaluacion
    {
        public Evaluacion()
        {
            Nota = new HashSet<Notum>();
        }

        public int CodigoEvaluacion { get; set; }
        public string Evaluacion1 { get; set; }
        public int Porcentaje { get; set; }
        public int? Curso { get; set; }

        public virtual CursoProfesor CursoNavigation { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
