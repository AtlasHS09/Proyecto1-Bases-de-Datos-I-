-- Lermith Biarreta Portillo y Adrián Herrera Segura

-- Base de datos que administra la información de un colegio
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

create table grupo
(
    codigoGrupo int NOT NULL CHECK (codigoGrupo > 0),
    profesor varchar(80) NOT NULL,
    periodo int NOT NULL CHECK (periodo > 0),
    cupo int NOT NULL CHECK (cupo > 0),
    materia varchar(30) NOT NULL,
    grado int NOT NULL CHECK (grado > 0),
    notaMinima int NOT NULL CHECK (notaMinima > 0),
    cedulaProfesor int,
    PRIMARY KEY (codigoGrupo),
    FOREIGN KEY (cedulaProfesor) REFERENCES profesor(cedulaProfesor)
);

create table estudiante
(
    cedulaEstudiante int,
    gradosCursados int NOT NULL CHECK (gradosCursados > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cursoActual varchar(50) NOT NULL,
    estadoPeriodo varchar(20) NOT NULL,
    grupo int NOT NULL,
    PRIMARY KEY (cedulaEstudiante),
    FOREIGN KEY (cedulaEstudiante) REFERENCES usuario(cedula),
    FOREIGN KEY (grupo) REFERENCES grupo(codigoGrupo)
);



create table periodoLectivo
(
    numeroPeriodo int NOT NULL CHECK (numeroPeriodo > 0),
    ano int NOT NULL CHECK (ano < 2021),
    fechaInicio date NOT NULL,
    fechaFinal date NOT NULL,
    cursoCerrado varchar(20) NOT NULL,
    cursoPendiente varchar(20) NOT NULL,
    cedulaEstudiante int NOT NULL,
    PRIMARY KEY (numeroPeriodo, ano),
    FOREIGN KEY (cedulaEstudiante) REFERENCES estudiante(cedulaEstudiante)
);

create table horarioClases
(
    CodigoCurso int NOT NULL,
    NombreCurso varchar(20) NOT NULL,
    periodoActual int NOT NULL,
    ano int NOT NULL,
    aula int NOT NULL CHECK (aula > 0),
    profesor int NOT NULL,
    PRIMARY KEY (CodigoCurso),
    FOREIGN KEY (periodoActual, ano) REFERENCES periodoLectivo(numeroPeriodo, ano),
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
    FOREIGN KEY (curso) REFERENCES horarioClases(CodigoCurso)
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

create table matricula
(
    cedulaEstudiante int NOT NULL CHECK (cedulaEstudiante > 0),
    periodoMatricular int NOT NULL CHECK (periodoMatricular > 0),
    ano int NOT NULL CHECK (ano > 0),
    cobrosPendientes int NOT NULL CHECK (cobrosPendientes > 0),
    montoMatricula DECIMAL(13, 4) NOT NULL,
    profesionPadre varchar(30),
    cedulaPadre int,
    PRIMARY KEY(cedulaEstudiante, periodoMatricular, ano),
    FOREIGN KEY (cedulaPadre) REFERENCES padre(cedulaPadre)
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


