using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class MateriaGrado
    {
        public MateriaGrado()
        {
            Grupos = new HashSet<Grupo>();
            Profesors = new HashSet<Profesor>();
        }

        public int IdMateriaGrado { get; set; }
        public string NombreMateria { get; set; }
        public int Grado { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }
    }
}
