using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Profesor
    {
        public Profesor()
        {
            Grupos = new HashSet<Grupo>();
            HistorialSalarios = new HashSet<HistorialSalario>();
        }

        public int IdProfesor { get; set; }
        public int IdMateriaGrado { get; set; }
        public decimal Salario { get; set; }

        public virtual MateriaGrado IdMateriaGradoNavigation { get; set; }
        public virtual Usuario IdProfesorNavigation { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<HistorialSalario> HistorialSalarios { get; set; }
    }
}
