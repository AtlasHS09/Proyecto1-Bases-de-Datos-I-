using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            Estudiantes = new HashSet<Estudiante>();
            Evaluacions = new HashSet<Evaluacion>();
        }

        public int CodigoGrupo { get; set; }
        public int Periodo { get; set; }
        public int Cupo { get; set; }
        public int MateriaGrado { get; set; }
        public int NotaMinima { get; set; }
        public string NombreCurso { get; set; }
        public int Anno { get; set; }
        public int Aula { get; set; }
        public int? CedulaProfesor { get; set; }
        public string Estado { get; set; }

        public virtual Profesor CedulaProfesorNavigation { get; set; }
        public virtual MateriaGrado MateriaGradoNavigation { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
    }
}
