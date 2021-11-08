using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class PeriodoLectivo
    {
        public PeriodoLectivo()
        {
            CursoProfesors = new HashSet<CursoProfesor>();
        }

        public int NumeroPeriodo { get; set; }
        public int Ano { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string EstadoCurso { get; set; }

        public virtual ICollection<CursoProfesor> CursoProfesors { get; set; }
    }
}
