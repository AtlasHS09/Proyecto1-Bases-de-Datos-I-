using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int CodigoGrupo { get; set; }
        public string Profesor { get; set; }
        public int Periodo { get; set; }
        public int Cupo { get; set; }
        public string Materia { get; set; }
        public int Grado { get; set; }
        public int NotaMinima { get; set; }
        public int? CedulaProfesor { get; set; }

        public virtual Profesor CedulaProfesorNavigation { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
