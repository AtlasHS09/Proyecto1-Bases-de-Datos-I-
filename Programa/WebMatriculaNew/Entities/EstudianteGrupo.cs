using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class EstudianteGrupo
    {
        public int CedulaEstudiante { get; set; }
        public int Grupo { get; set; }

        public virtual Usuario CedulaEstudianteNavigation { get; set; }
        public virtual Grupo GrupoNavigation { get; set; }
    }
}

