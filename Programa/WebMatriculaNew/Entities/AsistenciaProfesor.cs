using System;
namespace WebMatriculaNew.Entities
{
    public partial class AsistenciaProfesor
    {
        public int CedulaProfesor { get; set; }
        public int? Porcentaje { get; set; }

        public virtual Profesor CedulaProfesorNavigation { get; set; }
    }
}