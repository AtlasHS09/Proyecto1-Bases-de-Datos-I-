using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class EstudianteGrupo
    {
        public int IdEstudiante { get; set; }
        public int IdGrupo { get; set; }

        public virtual Usuario IdEstudianteNavigation { get; set; }
        public virtual Grupo IdGrupoNavigation { get; set; }
    }
}
