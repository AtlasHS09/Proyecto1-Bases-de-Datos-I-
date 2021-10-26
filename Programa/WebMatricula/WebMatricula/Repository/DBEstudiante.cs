using System;
using System.Collections.Generic;
using System.Linq;
using WebMatricula.Entities;

namespace WebMatricula.Repository
{
    public class DBEstudianteData : IEstudianteData
    {

        private matriculaContext _matriculaContext;

        public DBEstudianteData(matriculaContext matriculaContext)
        {
            _matriculaContext = matriculaContext;
        }


        public Estudiante add(Estudiante cliente)
        {
            _matriculaContext.Estudiantes.Add(cliente);
            _matriculaContext.SaveChanges();
            return cliente;
        }

        public void delete(int cedula)
        {
            var oldcliente = _matriculaContext.Estudiantes.SingleOrDefault(x => x.CedulaEstudiante == cedula);
            if (oldcliente != null)
            {
                _matriculaContext.Estudiantes.Remove(oldcliente);
                _matriculaContext.SaveChanges();
            }
        }

        public Estudiante get(int cedula)
        {
            return _matriculaContext.Estudiantes.SingleOrDefault(x => x.CedulaEstudiante == cedula);
        }

        public List<Estudiante> list()
        {
            return _matriculaContext.Estudiantes.ToList();
        }

        public Estudiante update(Estudiante estudiante)
        {
            var upEstudiante = _matriculaContext.Estudiantes.Find(estudiante.CedulaEstudiante);
            if (upEstudiante != null)
            {
                upEstudiante.CedulaEstudiante = estudiante.CedulaEstudiante;
                upEstudiante.GradosCursados = estudiante.GradosCursados;
                upEstudiante.Periodo = estudiante.Periodo;
                upEstudiante.CursoActual = estudiante.CursoActual;
                upEstudiante.EstadoPeriodo = estudiante.EstadoPeriodo;
                upEstudiante.Grupo = estudiante.Grupo;

                _matriculaContext.Estudiantes.Update(upEstudiante);
                _matriculaContext.SaveChanges();
            }
            return upEstudiante;
        }
    }
}
