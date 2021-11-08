using System;
namespace WebMatriculaNew.Entities
{

    public partial class NotaXEvaluacionXGrupo
    {
        public String Evaluacion { get; set; }
        public int? Porcentaje { get; set; }
        public int CedulaEstudiante { get; set; }
        public int Resultado { get; set; }

    }
}
