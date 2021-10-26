using System;
using System.Collections.Generic;
using WebMatricula.Entities;

namespace WebMatricula.Repository
{
    public interface IEstudianteData
    {

     List<Estudiante> list();

     Estudiante get(int cedula);

     Estudiante add(Estudiante estudiante);

     void delete(int cedula);

     Estudiante update(Estudiante estudiante);

    }
}
