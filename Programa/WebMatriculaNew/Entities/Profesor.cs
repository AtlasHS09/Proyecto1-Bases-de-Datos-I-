using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Profesor
    {
        public Profesor()
        {
            CursoProfesors = new HashSet<CursoProfesor>();
            Grupos = new HashSet<Grupo>();
        }

        public int CedulaProfesor { get; set; }
        public string MateriaImpartida { get; set; }
        public decimal Salario { get; set; }

        public virtual Usuario CedulaProfesorNavigation { get; set; }
        public virtual ICollection<CursoProfesor> CursoProfesors { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual AsistenciaProfesor AsistenciaProfesor { get; set; }
    }
}
