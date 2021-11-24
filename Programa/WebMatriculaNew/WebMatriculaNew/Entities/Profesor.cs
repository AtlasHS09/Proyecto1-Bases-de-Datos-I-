using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class Profesor
    {
        public Profesor()
        {
            Grupos = new HashSet<Grupo>();
            HistorialSalarios = new HashSet<HistorialSalario>();
        }

        public int CedulaProfesor { get; set; }
        public string MateriaImpartida { get; set; }
        public decimal Salario { get; set; }

        public virtual Usuario CedulaProfesorNavigation { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<HistorialSalario> HistorialSalarios { get; set; }
    }
}
