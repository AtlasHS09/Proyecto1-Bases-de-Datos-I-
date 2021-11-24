using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class MateriaGrado
    {
        public MateriaGrado()
        {
            Grupos = new HashSet<Grupo>();
        }

        public int CodigoMateriaGrado { get; set; }
        public string NombreMateria { get; set; }
        public int Grado { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}
