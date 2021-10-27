-- Lermith Biarreta Portillo y Adri�n Herrera Segura

-- Base de datos que administra la informaci�n de un colegio
-- Matriculas, mensualidades,  horarios, clases, profesores, etc.

use master
go
ALTER DATABASE matricula set single_user with rollback immediate
go
DROP DATABASE IF EXISTS matricula;
go
create database matricula;
go
use matricula;
go

-- Creaci�n de tablas

-- Tabla que posee la informaci�n general que posee un usuario registrado en la base de datos.

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

-- Tabla que posee la informaci�n de un usuario de categor�a profesor.

create table profesor
(
	cedulaProfesor int,
	materiaImpartida varchar(30) NOT NULL,
	salario int NOT NULL,
	PRIMARY KEY (cedulaProfesor),
	FOREIGN KEY (cedulaProfesor) REFERENCES usuario(cedula)
);

-- Tabla que posee la informaci�n del grupo que va a manejar el profesor a cargo.

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

-- Tabla que posee la informaci�n de un usuario de categor�a estudiante.

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

-- Tabla que posee la informaci�n del periodo lectivo en el que se encuentra el estudiante.

create table periodoLectivo
(
	numeroPeriodo int NOT NULL CHECK (numeroPeriodo > 0),
	a�o int NOT NULL CHECK (a�o < 2021),
	fechaInicio date NOT NULL,
	fechaFinal date NOT NULL,
	cursoCerrado varchar(20) NOT NULL,
	cursoPendiente varchar(20) NOT NULL,
	cedulaEstudiante int NOT NULL,
	PRIMARY KEY (numeroPeriodo, a�o),
	FOREIGN KEY (cedulaEstudiante) REFERENCES estudiante(cedulaEstudiante)
);

-- Tabla que posee la informaci�n del horario de clases de cada estudiante.

create table horarioClases
(
	CodigoCurso int NOT NULL,
	NombreCurso varchar(20) NOT NULL,
	periodoActual int NOT NULL,
	a�o int NOT NULL,
	aula int NOT NULL CHECK (aula > 0),
	profesor int NOT NULL,
	PRIMARY KEY (CodigoCurso),
	FOREIGN KEY (periodoActual, a�o) REFERENCES periodoLectivo(numeroPeriodo, a�o),
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

-- Tabla que posee la informaci�n de un usuario de categor�a padre.

create table padre
(
	cedulaPadre int NOT NULL,
	profesion varchar(30) NOT NULL,
	conyugue varchar(60),
	telefonoConyugue varchar(8),
	costoMensualidad int NOT NULL,
	pagosRealizados int NOT NULL,
	PRIMARY KEY (cedulaPadre),
	FOREIGN KEY (cedulaPadre) REFERENCES usuario(cedula)
);

-- Tabla que posee la informaci�n de la matricula de cada estudiante del colegio.

create table matricula
(
	cedulaEstudiante int NOT NULL CHECK (cedulaEstudiante > 0),
	periodoMatricular int NOT NULL CHECK (periodoMatricular > 0),
	a�o int NOT NULL CHECK (a�o > 0),
	cobrosPendientes int NOT NULL CHECK (cobrosPendientes > 0),
	montoMatricula int NOT NULL,
	profesionPadre varchar(30),
	cedulaPadre int,
	PRIMARY KEY(cedulaEstudiante, periodoMatricular, a�o),
	FOREIGN KEY (cedulaPadre) REFERENCES padre(cedulaPadre)
);

-- Tabla con la informaci�n que debe tener la factura que se le hace al padre al pagar la matr�cula.

create table factura
(
	cedulaPadre int NOT NULL CHECK (cedulaPadre > 0),
	periodo int NOT NULL,
	a�o int NOT NULL,
	fechaPago date NOT NULL,
	montoTotal int NOT NULL,
	cedulaEstudiante int NOT NULL,
	PRIMARY KEY (cedulaPadre),
	FOREIGN KEY (cedulaEstudiante, periodo, a�o) REFERENCES matricula(cedulaEstudiante, periodoMatricular, a�o)
);

-- ------------------------- Creaci�n de Vistas --------------------------------------------------;

GO
CREATE VIEW informacionEvaluaciones as -- Lanza informaci�n general de las evaluaciones (Profesores)
	(SELECT evaluacion, porcentaje FROM [dbo].[evaluaciones], [dbo].[horarioClases]
		WHERE CodigoCurso = curso)

GO
CREATE VIEW controlCobrosAdeudados as -- Lanza informaci�n de los pagos necesarios por estudiante (Padres)
	(SELECT cobrosPendientes, montoMatricula, costoMensualidad, pagosRealizados FROM [dbo].[matricula], [dbo].[padre]
		WHERE [dbo].[padre].[cedulaPadre] = [dbo].[matricula].[cedulaPadre])

GO
CREATE VIEW informacionEstudiante as -- Lanza informaci�n general de los estudiantes (padres)
	(SELECT [dbo].[estudiante].[cedulaEstudiante], gradosCursados, grupo, cursoActual FROM [dbo].[estudiante], [dbo].[matricula]
		WHERE [dbo].[estudiante].[cedulaEstudiante] = [dbo].[matricula].[cedulaEstudiante])

GO
CREATE VIEW informacionGradoEstudiante as -- Lanza informaci�n general del grado cursado (estudiantes)
	(SELECT gradosCursados, grupo, periodo, cursoActual FROM [dbo].[estudiante], [dbo].[matricula]
		WHERE [dbo].[estudiante].[cedulaEstudiante] = [dbo].[matricula].[cedulaEstudiante])

GO
CREATE VIEW informacionCurso as -- Lanza informaci�n general del curso y el horario del estudiante (estudiantes)
	(SELECT CodigoCurso, NombreCurso, aula, cedulaProfesor  FROM [dbo].[horarioClases], [dbo].[grupo]
	 WHERE materia = NombreCurso)



