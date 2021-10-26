using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class PeriodoLectivo
    {
        public PeriodoLectivo()
        {
            HorarioClases = new HashSet<HorarioClase>();
        }

        public int NumeroPeriodo { get; set; }
        public int Ano { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string CursoCerrado { get; set; }
        public string CursoPendiente { get; set; }
        public int CedulaEstudiante { get; set; }

        public virtual Estudiante CedulaEstudianteNavigation { get; set; }
        public virtual ICollection<HorarioClase> HorarioClases { get; set; }
    }
}
