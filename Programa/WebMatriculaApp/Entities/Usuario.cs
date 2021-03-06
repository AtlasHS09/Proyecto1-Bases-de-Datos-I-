using System;
using System.Collections.Generic;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            EstudianteGrupos = new HashSet<EstudianteGrupo>();
        }

        public int IdUsuario { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Provincia { get; set; }
        public string Residencia { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual Padre Padre { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<EstudianteGrupo> EstudianteGrupos { get; set; }
    }

    public enum ProvinciaOpciones
    {
        Alajuela,
        Cartago,
        Heredia,
        San_José,
        Guanacaste,
        Limón,
        Puntarenas
    }

    public enum Genero
    {
        Masculino,
        Femenino
    }
}
