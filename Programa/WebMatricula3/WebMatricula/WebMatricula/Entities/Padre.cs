using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class Padre
    {
        public Padre()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int CedulaPadre { get; set; }
        public string Profesion { get; set; }
        public string Conyugue { get; set; }
        public string TelefonoConyugue { get; set; }
        public decimal CostoMensualidad { get; set; }
        public int PagosRealizados { get; set; }

        public virtual Usuario CedulaPadreNavigation { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
