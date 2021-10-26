using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class HorarioClase
    {
        public int CodigoCurso { get; set; }
        public string NombreCurso { get; set; }
        public int PeriodoActual { get; set; }
        public int Ano { get; set; }
        public int Aula { get; set; }
        public int Profesor { get; set; }

        public virtual PeriodoLectivo PeriodoLectivo { get; set; }
        public virtual Profesor ProfesorNavigation { get; set; }
    }
}
