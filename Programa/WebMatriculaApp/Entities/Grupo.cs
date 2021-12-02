using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            EstudianteGrupos = new HashSet<EstudianteGrupo>();
            Evaluacions = new HashSet<Evaluacion>();
        }

        public int IdGrupo { get; set; }
        public int Periodo { get; set; }
        public int Cupo { get; set; }
        public int IdMateriaGrado { get; set; }
        public int NotaMinima { get; set; }
        public int Aula { get; set; }
        public string Estado { get; set; }
        public int? IdProfesor { get; set; }

        public virtual MateriaGrado IdMateriaGradoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
        public virtual PeriodoLectivo PeriodoNavigation { get; set; }
        public virtual ICollection<EstudianteGrupo> EstudianteGrupos { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
    }
}
