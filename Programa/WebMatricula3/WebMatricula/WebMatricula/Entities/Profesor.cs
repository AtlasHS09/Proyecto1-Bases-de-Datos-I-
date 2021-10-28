using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Profesor
    {
        public Profesor()
        {
            Grupos = new HashSet<Grupo>();
            HorarioClases = new HashSet<HorarioClase>();
        }

        public int CedulaProfesor { get; set; }
        public string MateriaImpartida { get; set; }
        public decimal Salario { get; set; }

        public virtual Usuario CedulaProfesorNavigation { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<HorarioClase> HorarioClases { get; set; }
    }
}
