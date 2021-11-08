-- Lermith Biarreta Portillo y Adri�n Herrera Segura

-- Base de datos que administra la informaci�n de un colegio
-- Matriculas, mensualidades,  horarios, clases, profesores, etc.

DROP DATABASE IF EXISTS matricula;
create database matricula;

use matricula;



create table usuario
(
    cedula int NOT NULL CHECK (cedula > 0),
    nombreCompleto varchar(60) NOT NULL,
    sexo varchar(20) NOT NULL,
    fechaNacimiento date NOT NULL,
    edad int NOT NULL CHECK (edad > 0),
    provincia varchar(20) NOT NULL,
    residencia varchar(50) NOT NULL,
    telefono varchar(8) NOT NULL,
    fechaCreacion date NOT NULL,
    PRIMARY KEY (cedula)
);


create table profesor
(
    cedulaProfesor int,
    materiaImpartida varchar(30) NOT NULL,
    salario DECIMAL(13, 4) NOT NULL,
    PRIMARY KEY (cedulaProfesor),
    FOREIGN KEY (cedulaProfesor) REFERENCES usuario(cedula)
);


create table materiaGrado
(
    codigoMateriaGrado int NOT NULL, 
    nombreMateria varchar(30) NOT NULL,
    grado int NOT NULL CHECK (grado > 0),
    PRIMARY KEY (codigoMateriaGrado)
);

create table grupo
(
    codigoGrupo int NOT NULL CHECK (codigoGrupo > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cupo int NOT NULL CHECK (cupo > 0),
    materiaGrado int NOT NULL,
    notaMinima int NOT NULL CHECK (notaMinima > 0),
    cedulaProfesor int,
    estado varchar(30) NOT NULL,
    PRIMARY KEY (codigoGrupo),
    FOREIGN KEY (cedulaProfesor) REFERENCES profesor(cedulaProfesor),
    FOREIGN KEY (materiaGrado) REFERENCES materiaGrado(codigoMateriaGrado)
);


create table padre
(
    cedulaPadre int NOT NULL,
    profesion varchar(30) NOT NULL,
    conyugue varchar(60),
    telefonoConyugue varchar(8),
    costoMensualidad DECIMAL(13, 4) NOT NULL,
    pagosRealizados int NOT NULL,
    PRIMARY KEY (cedulaPadre),
    FOREIGN KEY (cedulaPadre) REFERENCES usuario(cedula)
);

create table estudiante
(
    cedulaEstudiante int,
    gradosCursados int NOT NULL CHECK (gradosCursados > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cursoActual varchar(50) NOT NULL,
    estadoPeriodo varchar(20) NOT NULL,
    cedulaPadre  int NOT NULL,
    PRIMARY KEY (cedulaEstudiante),
    FOREIGN KEY (cedulaEstudiante) REFERENCES usuario(cedula),
    FOREIGN KEY (cedulaPadre) REFERENCES padre(cedulaPadre)
);

create table estudianteGrupo
(
    cedulaEstudiante int,
    grupo int NOT NULL,
    PRIMARY KEY (cedulaEstudiante,grupo),
    FOREIGN KEY (cedulaEstudiante) REFERENCES usuario(cedula),
    FOREIGN KEY (grupo) REFERENCES grupo(codigoGrupo)
);

create table asistenciaEstudiante
(
    cedulaEstudiante int NOT NULL,
    porcentaje int,
    PRIMARY KEY (cedulaEstudiante),
    FOREIGN KEY (cedulaEstudiante) references estudiante(cedulaEstudiante)
);

create table asistenciaProfesor
(
    cedulaProfesor int NOT NULL,
    porcentaje int,
    PRIMARY KEY (cedulaProfesor),
    FOREIGN KEY (cedulaProfesor) references profesor(cedulaProfesor)
);

create table periodoLectivo
(
    numeroPeriodo int NOT NULL CHECK (numeroPeriodo > 0),
    ano int NOT NULL CHECK (ano > 1999),
    fechaInicio date NOT NULL,
    fechaFinal date NOT NULL,
    estadoCurso varchar(20) NOT NULL,
    PRIMARY KEY (numeroPeriodo, ano)
);

create table cursoProfesor
(
    codigoCurso int NOT NULL,
    nombreCurso varchar(20) NOT NULL,
    periodo int NOT NULL,
    ano int NOT NULL,
    aula int NOT NULL CHECK (aula > 0),
    profesor int NOT NULL,
    PRIMARY KEY (codigoCurso),
    FOREIGN KEY (periodo, ano) REFERENCES periodoLectivo(numeroPeriodo, ano),
    FOREIGN KEY (profesor) REFERENCES profesor(cedulaProfesor)

);


-- Tabla de posee la tabla de evaluaciones de los cursos del colegio

create table evaluacion
(
    codigoEvaluacion int NOT NULL, 
    evaluacion varchar(30) NOT NULL,
    porcentaje int NOT NULL CHECK (porcentaje BETWEEN 1 AND 100),
    curso int,
    PRIMARY KEY (codigoEvaluacion),
    FOREIGN KEY (curso) REFERENCES cursoProfesor(CodigoCurso)
);



create table nota
(
    codigoEvaluacion int NOT NULL,
    cedulaEstudiante int NOT NULL,
    resultado int NOT NULL,
    PRIMARY KEY (codigoEvaluacion, cedulaEstudiante),
    FOREIGN KEY (codigoEvaluacion) REFERENCES evaluacion(codigoEvaluacion),
    FOREIGN KEY (cedulaEstudiante) REFERENCES estudiante(cedulaEstudiante)
);


create table matricula
(
    cedulaEstudiante int NOT NULL CHECK (cedulaEstudiante > 0),
    periodoMatricular int NOT NULL CHECK (periodoMatricular > 0),
    ano int NOT NULL CHECK (ano > 0),
    cobrosPendientes int NOT NULL CHECK (cobrosPendientes > 0),
    montoMatricula DECIMAL(13, 4) NOT NULL,
    PRIMARY KEY(cedulaEstudiante, periodoMatricular, ano)
);


create table factura
(
    cedulaPadre int NOT NULL CHECK (cedulaPadre > 0),
    periodo int NOT NULL,
    ano int NOT NULL,
    fechaPago date NOT NULL,
    montoTotal DECIMAL(13, 4) NOT NULL,
    cedulaEstudiante int NOT NULL,
    PRIMARY KEY (cedulaPadre),
    FOREIGN KEY (cedulaEstudiante, periodo, ano) REFERENCES matricula(cedulaEstudiante, periodoMatricular, ano)
);



insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, edad, provincia,residencia,telefono, fechaCreacion ) 
values (20203354, 'Lermith Biarreta', 'Masculino', '1999-11-05', 50, 'Alajuela', 'Mi direccion', '234234', '2021-05-20');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, edad, provincia,residencia,telefono, fechaCreacion ) 
values (39393939, 'Adrian Herrera', 'Masculino', '2001-11-05', 50, 'Alajuela', 'Mi direccion', '234234', '2021-05-20');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, edad, provincia,residencia,telefono, fechaCreacion ) 
values (37374747, 'Pedro Perez', 'Masculino', '2001-11-05', 50, 'Alajuela', 'Mi direccion', '234554', '2021-05-20');


insert into profesor (cedulaProfesor, materiaImpartida, salario) values (20203354, 'Materia1', 20200);

insert into materiaGrado (codigoMateriaGrado, nombreMateria, grado) 
values (0001, 'Materia1', 7);

insert into grupo (codigoGrupo, periodo, cupo, materiaGrado, notaMinima, cedulaProfesor, estado) 
values (0001, 11, 30, 001, 70, 20203354, 'Abierto');

insert into periodoLectivo (numeroPeriodo, ano, fechaInicio, fechaFinal, estadoCurso) 
values (11, 2022, '2021-11-05', '2022-03-05', 'Pendiente');

insert into padre (cedulaPadre, profesion, conyugue, telefonoConyugue, costoMensualidad, pagosRealizados) 
values (37374747, 'Cirujana', 'Amanda Morales', '234234', 7000, 3);

insert into estudiante (cedulaEstudiante, gradosCursados, periodo, cursoActual, estadoPeriodo, cedulaPadre) 
values (39393939, 8, 11, 7, 'Abierto', 37374747);

insert into cursoProfesor (CodigoCurso, NombreCurso, periodo, ano, aula, profesor)
values (7, 'Materia1', 11, 2022, 105, 20203354);

insert into evaluacion (codigoEvaluacion, evaluacion, porcentaje, curso)
values (001, 'Examen 1', 45, 7);

insert into evaluacion (codigoEvaluacion, evaluacion, porcentaje, curso)
values (002, 'Examen 2', 45, 7);

insert into matricula (cedulaEstudiante, periodoMatricular, ano, cobrosPendientes, montoMatricula)
values (39393939, 3, 2022, 3, 1500);

insert into asistenciaEstudiante (cedulaEstudiante, porcentaje) 
values (39393939, 80);

insert into nota (codigoEvaluacion, cedulaEstudiante, resultado) 
values (001, 39393939, 80);

insert into estudianteGrupo (cedulaEstudiante, grupo) 
values (39393939, 001);
