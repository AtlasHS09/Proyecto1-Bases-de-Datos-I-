using System;

namespace WebMatriculaNew.Entities
{
    public partial class AsistenciaXGrupo
    {
        public int CedulaEstudiante { get; set; }
        public int? Porcentaje { get; set; }
        public int? CodigoGrupo { get; set; }

        public virtual Estudiante CedulaEstudianteNavigation { get; set; }
        public virtual Grupo CodigoGrupoNavigation { get; set; }
    }
}

