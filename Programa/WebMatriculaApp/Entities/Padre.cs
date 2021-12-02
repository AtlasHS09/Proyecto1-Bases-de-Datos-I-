using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Padre
    {
        public Padre()
        {
            CobroFacturas = new HashSet<CobroFactura>();
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdPadre { get; set; }
        public string Profesion { get; set; }
        public string Conyugue { get; set; }
        public string TelefonoConyugue { get; set; }

        public virtual Usuario IdPadreNavigation { get; set; }
        public virtual ICollection<CobroFactura> CobroFacturas { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
