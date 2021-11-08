using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            EstudianteGrupos = new HashSet<EstudianteGrupo>();
        }

        public int CodigoGrupo { get; set; }
        public int Periodo { get; set; }
        public int Cupo { get; set; }
        public int MateriaGrado { get; set; }
        public int NotaMinima { get; set; }
        public int? CedulaProfesor { get; set; }
        public string Estado { get; set; }

        public virtual Profesor CedulaProfesorNavigation { get; set; }
        public virtual MateriaGrado MateriaGradoNavigation { get; set; }
        public virtual ICollection<EstudianteGrupo> EstudianteGrupos { get; set; }
    }
}
