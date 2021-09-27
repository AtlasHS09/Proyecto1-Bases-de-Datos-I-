use master
go
DROP DATABASE IF EXISTS matricula -- Borra la base de datos
go
create database matricula;
go
use matricula;
go

--Creaci�n de tablas

create table usuario
(
	cedula int NOT NULL CHECK (cedula > 0),
	nombreCompleto varchar(60) NOT NULL,
	sexo varchar(20) NOT NULL,
	fechaNacimiento date NOT NULL,
	edad int NOT NULL CHECK (edad > 0),
	provincia varchar(20) NOT NULL,
	residencia varchar(50) NOT NULL,
	tel�fono int NOT NULL CHECK (tel�fono > 0),
	fechaCreacion date NOT NULL,
	PRIMARY KEY (cedula)
);

create table estudiantes
(
	gradosCursados int NOT NULL CHECK (gradosCursados > 0),
	periodo int NOT NULL CHECK (periodo > 0),
	cursoActual varchar(50) NOT NULL,
	estadoPeriodo varchar(20) NOT NULL,
	cedulaEstudiante int,
	PRIMARY KEY (gradosCursados),
	FOREIGN KEY (cedulaEstudiante) REFERENCES usuario(cedula)
);

create table periodoLectivo
(
	numeroPeriodo int NOT NULL CHECK (numeroPeriodo > 0),
	a�o int NOT NULL CHECK (a�o < 2021),
	fechaInicio date NOT NULL,
	fechaFinal date NOT NULL,
	periodoAbierto int NOT NULL CHECK (periodoAbierto > 0),
	cursosNoCerrados int NOT NULL CHECK (cursosNoCerrados > 0),
	cursosPendientes int NOT NULL CHECK (cursosPendientes > 0),
	gradosAnteriores int,
	PRIMARY KEY (numeroPeriodo),
	FOREIGN KEY (gradosAnteriores) REFERENCES estudiantes(gradosCursados)
);

create table HorarioClases
(
	curso varchar(30) NOT NULL,
	aula int NOT NULL CHECK (aula > 0),
	profesor varchar(80) NOT NULL,
	matrizEvaluaciones varchar(100) NOT NULL,
	periodoActual int,
	PRIMARY KEY (curso),
	FOREIGN KEY (periodoActual) REFERENCES periodoLectivo(numeroPeriodo)
);

create table padres
(
	profesion varchar(30) NOT NULL,
	conyugue varchar(60) NOT NULL,
	telefonoConyugue int NOT NULL CHECK (telefonoConyugue > 0),
	costoMensualidad money NOT NULL,
	pagosRealizados int NOT NULL,
	cedulaPadre int,
	PRIMARY KEY (profesion),
	FOREIGN KEY (cedulaPadre) REFERENCES usuario(cedula)
);

create table matricula
(
	cedulaEstudiante int NOT NULL CHECK (cedulaEstudiante > 0),
	periodoMatricular int NOT NULL CHECK (periodoMatricular > 0),
	cobrosPendientes int NOT NULL CHECK (cobrosPendientes > 0),
	montoMatricula money NOT NULL,
	profesionPadre varchar(30),
	PRIMARY KEY(cedulaEstudiante),
	FOREIGN KEY (profesionPadre) REFERENCES padres(profesion)
);

create table factura
(
	cedulaPadre int NOT NULL CHECK (cedulaPadre > 0),
	fechaPago date NOT NULL,
	montoTotal money NOT NULL,
	cedulaEstudiante int,
	PRIMARY KEY (cedulaPadre),
	FOREIGN KEY (cedulaEstudiante) REFERENCES matricula(cedulaEstudiante)
);

create table profesores
(
	materiaImpartida varchar(30) NOT NULL,
	salario money NOT NULL,
	cedulaProfesor int,
	PRIMARY KEY (materiaImpartida),
	FOREIGN KEY (cedulaProfesor) REFERENCES usuario(cedula)
);

create table grupos
(
	codigoGrupo int NOT NULL CHECK (codigoGrupo > 0),
	profesor varchar(80) NOT NULL,
	periodo int NOT NULL CHECK (periodo > 0),
	cupos int NOT NULL CHECK (cupos > 0),
	materia varchar(30) NOT NULL,
	grado int NOT NULL CHECK (grado > 0),
	nombre varchar(30),
	PRIMARY KEY (codigoGrupo),
	FOREIGN KEY (nombre) REFERENCES profesores(materiaImpartida)
);