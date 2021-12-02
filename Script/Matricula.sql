--III Parte del proyecto de Bases de Datos I
--Lermith Biarreta y Adrián Herrera
--Base de datos que guarda la información de toda la parte administrativa de un centro educativo

DROP DATABASE IF EXISTS matricula2;
create database matricula2;

use matricula2;

----------------------------CREACION DE TABLAS-------------------------------------------------------

create table usuario
(
    id_usuario int(11) AUTO_INCREMENT,
    cedula varchar(14) NOT NULL,
    nombreCompleto varchar(60) NOT NULL,
    sexo varchar(20) NOT NULL,
    fechaNacimiento date NOT NULL,
    edad int NOT NULL CHECK (edad > 0),
    provincia varchar(20) NOT NULL,
    residencia varchar(50) NOT NULL,
    telefono varchar(8) NOT NULL,
    fechaCreacion date NOT NULL,
    PRIMARY KEY (id_usuario),
    CONSTRAINT uc_usuario UNIQUE (cedula)
);
create table materiaGrado
(
    id_materiaGrado int NOT NULL, 
    nombreMateria varchar(30) NOT NULL,
    grado int NOT NULL CHECK (grado > 0),
    PRIMARY KEY (id_materiaGrado)
);
create table profesor
(
    id_profesor int,
    id_materiaGrado int NOT NULL,
    salario DECIMAL(13, 4) NOT NULL,
    PRIMARY KEY (id_profesor),
    FOREIGN KEY (id_profesor) REFERENCES usuario(id_usuario),
    FOREIGN KEY (id_materiaGrado) REFERENCES materiaGrado(id_materiaGrado)
);
create table periodoLectivo
(
    id_periodo int(8) AUTO_INCREMENT,
    periodo int NOT NULL CHECK (periodo > 0),
    anno int NOT NULL CHECK (anno > 1999),
    fechaInicio date NOT NULL,
    fechaFinal date NOT NULL,
    estado varchar(20),
    PRIMARY KEY (id_periodo),
    CONSTRAINT uc_periodo UNIQUE (periodo, anno)
);
create table grupo
(
    id_grupo int NOT NULL CHECK (id_grupo > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cupo int NOT NULL CHECK (cupo > 0),
    id_materiaGrado int NOT NULL,
    notaMinima int NOT NULL CHECK (notaMinima > 0),
    aula int NOT NULL CHECK (aula > 0),
    estado varchar(30) NOT NULL,
    id_profesor int,
    PRIMARY KEY (id_grupo),
    FOREIGN KEY (periodo) REFERENCES periodoLectivo(id_periodo),
    FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor),
    FOREIGN KEY (id_materiaGrado) REFERENCES materiaGrado(id_materiaGrado)
);
create table padre
(
    id_padre int NOT NULL,
    profesion varchar(30) NOT NULL,
    conyugue varchar(60),
    telefonoConyugue varchar(8),
    PRIMARY KEY (id_padre),
    FOREIGN KEY (id_padre) REFERENCES usuario(id_usuario)
);
create table estudiante
(
    id_estudiante int,
    periodo int NOT NULL CHECK (periodo > 0),
    gradoActual int NOT NULL CHECK (gradoActual > 0),
    id_padre  int NOT NULL,
    PRIMARY KEY (id_estudiante),
    FOREIGN KEY (id_estudiante) REFERENCES usuario(id_usuario),
    FOREIGN KEY (id_padre) REFERENCES padre(id_padre)
);
create table estudianteGrupo
(
    id_estudiante int,
    id_grupo int NOT NULL,
    PRIMARY KEY (id_estudiante,id_grupo),
    FOREIGN KEY (id_estudiante) REFERENCES usuario(id_usuario),
    FOREIGN KEY (id_grupo) REFERENCES grupo(id_grupo)
    
);
create table inasistenciaEstudiante
(
    id_inasistenciaE int(10) AUTO_INCREMENT,
    id_estudiante int NOT NULL,
    fecha date NOT NULL,
    PRIMARY KEY (id_inasistenciaE),
    FOREIGN KEY (id_estudiante) references estudiante(id_estudiante),
    CONSTRAINT uc_inasistenciaEstudiante UNIQUE (id_estudiante, fecha)
);
create table evaluacion
(
    id_evaluacion int NOT NULL, 
    evaluacion varchar(30) NOT NULL,
    porcentaje int NOT NULL CHECK (porcentaje BETWEEN 1 AND 100),
    grupo int,
    PRIMARY KEY (id_evaluacion),
    FOREIGN KEY (grupo) REFERENCES grupo(id_grupo)
);
create table nota
(
    id_nota int(10) AUTO_INCREMENT,
    id_evaluacion int NOT NULL,
    id_estudiante int NOT NULL,
    resultado int NOT NULL,
    PRIMARY KEY (id_nota),
    FOREIGN KEY (id_evaluacion) REFERENCES evaluacion(id_evaluacion),
    FOREIGN KEY (id_estudiante) REFERENCES estudiante(id_estudiante),
    CONSTRAINT uc_nota UNIQUE (id_evaluacion, id_estudiante)
);
create table matricula
(
    id_matricula int(10) AUTO_INCREMENT,
    id_estudiante int NOT NULL CHECK (id_estudiante > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cobrosPendientes int NOT NULL CHECK (cobrosPendientes > -1),
    montoMatricula DECIMAL(13, 4) NOT NULL,
    PRIMARY KEY (id_matricula),
    FOREIGN KEY (id_estudiante) REFERENCES estudiante(id_estudiante),
    FOREIGN KEY (periodo) REFERENCES periodoLectivo(id_periodo),
    CONSTRAINT uc_matricula UNIQUE (id_estudiante, periodo)
);
create table cobroFactura
(
    id_cobroFactura int(10) AUTO_INCREMENT,
    id_matricula int NOT NULL CHECK (id_matricula > 0),
    numeroMensualidad int NOT NULL CHECK (numeroMensualidad > 0),
    id_padre int NOT NULL CHECK (id_padre > 0),
    cantidad double NOT NULL CHECK (cantidad > 0),
    fechaCobro date NOT NULL,
    fechaFactura date NOT NULL,
    estado varchar(20) NOT NULL,
    PRIMARY KEY (id_cobroFactura),
    FOREIGN KEY (id_matricula) REFERENCES matricula(id_matricula),
    FOREIGN KEY (id_padre) REFERENCES padre(id_padre)
);
create table historialSalarios
(
    id_profesor int NOT NULL,
    salario int NOT NULL,
    fecha date NOT NULL,
    PRIMARY KEY(id_profesor, fecha),
    FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor)
);

-----------------------CREACION DE INSERTS Y TRIGGERS-------------------------------------------------

create trigger primerSalario after insert 
on profesor 
for each row 
insert into historialSalarios (id_profesor, salario, fecha)
values (new.id_profesor, new.salario, now());

------------Inserts periodo lectivo-------------

insert into periodoLectivo (periodo, anno, fechaInicio, fechaFinal, estado) 
values (1, 2020, '2020-12-06','2021-12-06', 'Abierto');

insert into periodoLectivo (periodo, anno, fechaInicio, fechaFinal, estado) 
values (1, 2021, '2021-12-06','2022-12-06', 'Cerrado');

------------Inserts usuarios-------------

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000101', 'Estudiante1 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000102', 'Estudiante2 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000103', 'Estudiante3 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000104', 'Estudiante4 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000105', 'Estudiante5 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000106', 'Estudiante6 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000107', 'Estudiante7 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000108', 'Estudiante8 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000109', 'Estudiante9 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000110', 'Estudiante10 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000201', 'Estudiante1 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000202', 'Estudiante2 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000203', 'Estudiante3 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000204', 'Estudiante4 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000205', 'Estudiante5 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000206', 'Estudiante6 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000207', 'Estudiante7 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000208', 'Estudiante8 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000209', 'Estudiante9 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('1000210', 'Estudiante10 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

------------Inserts materia grado-------------

insert into materiaGrado (id_materiaGrado, nombreMateria, grado)
values (1, 'Materia2-1', 1);

insert into materiaGrado (id_materiaGrado, nombreMateria, grado)
values (2, 'Materia2-1', 1);

insert into materiaGrado (id_materiaGrado, nombreMateria, grado)
values (3, 'Materia3-1', 1);

insert into materiaGrado (id_materiaGrado, nombreMateria, grado)
values (4, 'Materia1-2', 2);

insert into materiaGrado (id_materiaGrado, nombreMateria, grado)
values (5, 'Materia2-2', 2);

insert into materiaGrado (id_materiaGrado, nombreMateria, grado)
values (6, 'Materia3-2', 2);

----------------------------------------------------------------------

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('2000101', 'Profesor1 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('2000102', 'Profesor2 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('2000103', 'Profesor3 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('2000201', 'Profesor1 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('2000202', 'Profesor2 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('2000203', 'Profesor3 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

------------------------------------------------------------------------------------------------

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000101', 'Padre1 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000102', 'Padre2 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000103', 'Padre3 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000104', 'Padre4 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000105', 'Padre5 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000106', 'Padre6 Periodo1', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000107', 'Padre7 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000108', 'Padre8 Periodo1', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

--------------------------------------------------------------------------------

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000201', 'Padre1 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000202', 'Padre2 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000203', 'Padre3 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000204', 'Padre4 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000205', 'Padre5 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000206', 'Padre6 Periodo2', 'Masculino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000207', 'Padre7 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

insert into usuario (cedula, nombreCompleto, sexo, fechaNacimiento, 
edad, provincia, residencia, telefono, fechaCreacion) 
values ('3000208', 'Padre8 Periodo2', 'Femenino', '2001-12-21', 17,
'Alajuela', 'Direccion', '99992222', '2021-12-21');

--------------Inserts Profesores--------------------------------

insert into profesor (id_profesor, id_materiaGrado, salario)
values (21, 1, 20200);

insert into profesor (id_profesor, id_materiaGrado, salario)
values (22, 2, 10200);

insert into profesor (id_profesor, id_materiaGrado, salario)
values (23, 3, 120000);

insert into profesor (id_profesor, id_materiaGrado, salario)
values (24, 4, 120000);

insert into profesor (id_profesor, id_materiaGrado, salario)
values (25, 5, 20200);

insert into profesor (id_profesor, id_materiaGrado, salario)
values (26, 6, 2000);

--------------Inserts Padres--------------------------------

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (27, 'Profesion', 'Conyugue', '10000001');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (28, 'Profesion', 'Conyugue', '10000002');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (29, 'Profesion', 'Conyugue', '10000003');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (30, 'Profesion', 'Conyugue', '10000004');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (31, 'Profesion', 'Conyugue', '10000005');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (32, 'Profesion', 'Conyugue', '10000006');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (33, 'Profesion', 'Conyugue', '10000078');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (34, 'Profesion', 'Conyugue', '10000910');

------------------------------------------------------------------------

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (35, 'Profesion', 'Conyugue', '20000001');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (36, 'Profesion', 'Conyugue', '20000002');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (37, 'Profesion', 'Conyugue', '20000003');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (38, 'Profesion', 'Conyugue', '20000004');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (39, 'Profesion', 'Conyugue', '20000005');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (40, 'Profesion', 'Conyugue', '20000006');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (41, 'Profesion', 'Conyugue', '20000078');

insert into padre (id_padre, profesion, conyugue, telefonoConyugue) 
values (42, 'Profesion', 'Conyugue', '20000910');


--------------Inserts Grupos--------------------------------

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (1, 1, 30, 1, 70, 15, 'Abierto', 21);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (2, 1, 30, 1, 70, 17, 'Abierto', 21);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (3, 1, 30, 2, 70, 17, 'Abierto', 22);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (4, 1, 30, 2, 70, 19, 'Abierto', 22);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (5, 1, 30, 3, 70, 21, 'Abierto', 23);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (6, 1, 30, 3, 70, 23, 'Abierto', 23);

--------------------------------------------------------------------

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (7, 2, 30, 4, 80, 25, 'Abierto', 24);	

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (8, 2, 30, 4, 80, 27, 'Abierto', 24);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (9, 2, 30, 5, 80, 29, 'Abierto', 25);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (10, 2, 30, 5, 80, 29, 'Abierto', 25);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (11, 2, 30, 6, 80, 31, 'Abierto', 26);

insert into grupo (id_grupo, periodo, cupo, id_materiaGrado, 
notaMinima, aula, estado, id_profesor)
values (12, 2, 30, 6, 80, 33, 'Abierto', 26);

--------------Inserts Estudiantes--------------------------------

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (1, 1, 1, 27);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (2, 1, 1, 28);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (3, 1, 1, 29);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (4, 1, 1, 30);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (5, 1, 1, 31);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (6, 1, 1, 32);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (7, 1, 1, 33);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (8, 1, 1, 33);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (9, 1, 1, 34);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (10, 1, 1, 34);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (11, 2, 2, 35);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (12, 2, 2, 36);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (13, 2, 2, 37);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (14, 2, 2, 38);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (15, 2, 2, 39);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (16, 2, 2, 40);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (17, 2, 2, 41);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (18, 2, 2, 41);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (19, 2, 2, 42);

insert into estudiante (id_estudiante, periodo, gradoActual, 
id_padre) values (20, 2, 2, 42);

-------------------------PROCEDIMIENTO DE MATRICULA-------------------------------------------

create procedure matricularEstudiante (new_estudiante int, 
new_periodo int, new_cobrosPendientes int, new_montoMatricula decimal(13,4))

begin

DECLARE counter INT DEFAULT 0;
	DECLARE errno INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
    GET CURRENT DIAGNOSTICS CONDITION 1 errno = MYSQL_ERRNO;
    SELECT errno AS MYSQL_ERROR;
    ROLLBACK;
    END;

   START TRANSACTION;
   
		insert into matricula (id_estudiante,
		periodo, cobrosPendientes, montoMatricula) values
		(new_estudiante, new_periodo, new_cobrosPendientes,
		new_montoMatricula);
		
		insert into estudianteGrupo (id_grupo, id_estudiante) 
		select id_grupo,id_estudiante from (
		select z.id_materiaGrado as id_materiaGrado,
		id_estudiante, min(id_grupo) as id_grupo from grupo as z  inner join materiaGrado as m 
		inner join estudiante as e on e.gradoActual = m.grado
		on z.id_materiaGrado = m.id_materiaGrado where e.id_estudiante = new_estudiante and z.periodo = e.periodo and z.id_grupo not in
		( select t1.id_grupo as id_grupo from
			(select count(id_estudiante) as cupoActual, id_grupo from estudianteGrupo
			group by id_grupo) as t1 inner join grupo as t2 on t1.id_grupo = t2.id_grupo where t1.cupoActual = t2.cupo)
		group by id_materiaGrado, id_estudiante) as g;
		    REPEAT
		        call facturarCobro(new_estudiante);
		        SET counter = counter + 1;
		    UNTIL counter >= new_cobrosPendientes
		    END REPEAT;
    COMMIT WORK;

end

-----------------ESTUDIANTES MATRICULADOS----------------------------------------------------

call matricularEstudiante(1,1,8,5000);
call matricularEstudiante(2,1,10,8000);
call matricularEstudiante(3,1,5,8000);
call matricularEstudiante(4,1,6,7000);
call matricularEstudiante(5,1,4,15000);
call matricularEstudiante(6,1,5,4000);
call matricularEstudiante(7,1,12,10000);
call matricularEstudiante(8,1,4,8000);
call matricularEstudiante(9,1,12,5000);
call matricularEstudiante(10,1,5,1000);

call matricularEstudiante(11,2,8,5000);
call matricularEstudiante(12,2,10,8000);
call matricularEstudiante(13,2,5,8000);
call matricularEstudiante(14,2,6,7000);
call matricularEstudiante(15,2,4,15000);
call matricularEstudiante(16,2,5,4000);
call matricularEstudiante(17,2,12,10000);
call matricularEstudiante(18,2,4,8000);
call matricularEstudiante(19,2,12,5000);
call matricularEstudiante(20,2,5,1000);

--------------Inserts evaluaciones--------------------------------

insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (1, "Examen1", 33, 1);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (2, "Examen2", 33, 1);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (3, "Examen3", 34, 1);
-- -------------------------------------

insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (4, "Examen4", 50, 3);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (5, "Examen5", 50, 3);

-- -------------------------------------
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (6, "Examen6", 40, 5);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (7, "Examen7", 60, 5);

-- -------------------------------------
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (8, "Examen8", 33, 7);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (9, "Examen9", 33, 7);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (10, "Examen10", 34, 7);

-- -------------------------------------
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (11, "Examen11", 33, 9);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (12, "Examen12", 33, 9);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (13, "Examen13", 34, 9);

-- -------------------------------------
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (14, "Examen14", 40, 11);
insert into evaluacion (id_evaluacion, evaluacion, porcentaje, 
grupo) values (15, "Examen15", 60, 11);

--------------Inserts Notas--------------------------------

insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (1, 1, 1, 50);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (2, 1, 2, 70);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (3, 1, 3, 50);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (4, 1, 4, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (5, 1, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (6, 1, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (7, 1, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (8, 1, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (9, 1, 9, 10);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (10, 1, 10, 100);

-- ------------------------------------
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (11, 2, 1, 50);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (12, 2, 2, 70);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (13, 2, 3, 50);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (14, 2, 4, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (15, 2, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (16, 2, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (17, 2, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (18, 2, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (19, 2, 9, 10);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (20, 2, 10, 100);

-- ------------------------------------
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (21, 3, 1, 50);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (22, 3, 2, 70);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (23, 3, 3, 50);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (24, 3, 4, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (25, 3, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (26, 3, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (27, 3, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (28, 3, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (29, 3, 9, 10);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (30, 3, 10, 100);

-- -------------------------------------
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (31, 4, 1, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (32, 4, 2, 80);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (33, 4, 3, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (34, 4, 4, 90);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (35, 4, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (36, 4, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (37, 4, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (38, 4, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (39, 4, 9, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (40, 4, 10, 100);

-- -------------------------------------
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (41, 5, 1, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (42, 5, 2, 80);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (43, 5, 3, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (44, 5, 4, 90);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (45, 5, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (46, 5, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (47, 5, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (48, 5, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (49, 5, 9, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (50, 5, 10, 100);

-- -------------------------------------

insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (51, 6, 1, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (52, 6, 2, 80);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (53, 6, 3, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (54, 6, 4, 90);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (55, 6, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (56, 6, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (57, 6, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (58, 6, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (59, 6, 9, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (60, 6, 10, 100);

-- ------------------------------------

insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (61, 7, 1, 40);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (62, 7, 2, 80);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (65, 7, 5, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (66, 7, 6, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (67, 7, 7, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (68, 7, 8, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (69, 7, 9, 100);
insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) 
values (70, 7, 10, 100);

-- -------------------------------- NOTAS OMITIDAS--------------------------------------

-- insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) values (63, 7, 3, 40);
-- insert into nota (id_nota, id_evaluacion, id_estudiante, resultado) values (64, 7, 4, 90);

---------------------------CREACION DE TRIGGERS--------------------------------------------------

create trigger tiempoDeCobro
before insert on cobroFactura for each row 
if new.fechaCobro is null then 
set new.fechaCobro = now(); 
end if;

create trigger tiempoDeFactura
before insert on cobroFactura for each row 
if new.fechaFactura is null then 
set new.fechaFactura = now(); 
end if;

create trigger estadoDeCobro
before insert on cobroFactura for each row 
if new.estado is null then 
set new.estado = 'Sin Pagar'; 
end if;

-------------PROCEDIMIENTO PARA FACTURAR CADA COBRO REALIZADO----------------------

create procedure facturarCobro (new_estudiante int) 
insert into cobroFactura (id_matricula, numeroMensualidad, 
id_padre, cantidad)
SELECT id_matricula, cobrosPendientes, id_padre, 
(montoMatricula/cobrosPendientes)
from
(select * from
(select matricula.id_matricula, matricula.cobrosPendientes, 
matricula.montoMatricula, matricula.id_estudiante as 
matriculaEstudiante from matricula 
inner join estudiante where matricula.id_estudiante = 
estudiante.id_estudiante) 
as m 
inner join 
(select padre.id_padre, estudiante.id_estudiante from padre 
inner join estudiante where estudiante.id_padre = padre.id_padre)
as p
where id_estudiante = matriculaEstudiante) 
as x
where id_estudiante = new_estudiante; 

------------------LLAMADA AL PROCEDIMIENTO ALMACENADO--------------------

call facturarCobro(1);
call facturarCobro(1);
call facturarCobro(1);
call facturarCobro(1);
call facturarCobro(1);
call facturarCobro(1);
call facturarCobro(1);
call facturarCobro(1);

call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);
call facturarCobro(2);

call facturarCobro(3);
call facturarCobro(3);
call facturarCobro(3);
call facturarCobro(3);
call facturarCobro(3);

call facturarCobro(4);
call facturarCobro(4);
call facturarCobro(4);
call facturarCobro(4);
call facturarCobro(4);
call facturarCobro(4);

call facturarCobro(5);
call facturarCobro(5);
call facturarCobro(5);
call facturarCobro(5);

call facturarCobro(6);
call facturarCobro(6);
call facturarCobro(6);
call facturarCobro(6);
call facturarCobro(6);

call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);
call facturarCobro(7);

call facturarCobro(8);
call facturarCobro(8);
call facturarCobro(8);
call facturarCobro(8);

call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);
call facturarCobro(9);

call facturarCobro(10);
call facturarCobro(10);
call facturarCobro(10);
call facturarCobro(10);
call facturarCobro(10);

-- Procedimiento que muestra el promedio total de rendimiento de los estudiantes de cada grupo, junto con el nombre del profesor

create procedure promedioDeNotasXprofesorXgrupo()
select AVG(n.resultado) as promedio, concat(us.cedula,' - grupo ', cast(ev.grupo as char)) as profesorGrupo
from nota as n inner join evaluacion as ev inner join grupo as g inner join profesor as p inner join usuario us on p.id_profesor = us.id_usuario 
where n.id_evaluacion = ev.id_evaluacion and ev.grupo = g.id_grupo and g.id_profesor = p.id_profesor 
group by us.nombreCompleto, ev.grupo;

-- Procedimiento que muestra la cantidad de estudiantes de cada grupo, dependiendo del periodo

create procedure cantidadDeEstudiantesXperiodoXgrupo()
select  
CONCAT(cast(pL.periodo as char) ,'-',cast(pL.anno as char),' ', 
cast(g.id_grupo as char), '-', mg.nombreMateria ) 
as periodoGrupo, count(distinct m.id_estudiante) as cantidad
    from matricula as m inner join grupo as g inner join 
    periodoLectivo as pL on pL.id_periodo = g.periodo 
    inner join materiaGrado mg  on g.id_materiaGrado
    =  mg.id_materiaGrado 
    where m.periodo = g.periodo  
    group by periodoGrupo;

-- Procedimiento que muestra los 10 padres con más pagos pendientes en el centro educativo.

create procedure top10PadresDeudas()   
select us.nombreCompleto as padre, sum(cf.cantidad) as cantidad from cobroFactura as cf inner join usuario as us on cf.id_padre = us.id_usuario 
    where estado <> 'Pendiente' 
    group by id_padre 
    order by cantidad DESC limit 10;
    
-- Procedimiento que muestra los ingresos totales que recibe el centro educativo dependiendo del grupo

create procedure ingresosXgrupoXperiodo()
select sum(cantidad) as ingreso, concat(cast(e.gradoActual as char),' ', cast(pl.periodo as char) ,'-', cast(pl.anno as char)) as grupoPeriodo from cobroFactura as cf 
inner join matricula as m on cf.id_matricula = m.id_matricula 
inner join estudiante as e on m.id_estudiante = e.id_estudiante 
inner join periodoLectivo as pl where e.periodo = pl.id_periodo and cf.estado = 'Pagado'
group by grupoPeriodo;

-- Procedimiento que muestra la cantidad de grupos activos por periodo lectivo

create procedure cantidadDeGruposXperiodo()
select count(id_grupo) as cantidad, concat(cast(pl.periodo as char), '-', cast(pl.anno as char)) as periodo 
from grupo as g inner join periodoLectivo pl on g.periodo = pl.id_periodo 
group by periodo;

-- Procedimiento que muestra los 10 estudiantes con más ausencias del centro educativo

create procedure top10EstudiantesAusencias()
select us.nombreCompleto as nombre , count(fecha) as cantidad from inasistenciaEstudiante as ina inner join usuario as us on ina.id_estudiante = us.id_usuario 
group by nombre
order by cantidad DESC 
limit 10;

-- Procedimiento que muestra las ausencias de cada estudiante de forma individual

create procedure EstudiantesAusenciasParticular(v_estudiante int)
select * from (select ina.id_estudiante as id_estudiante , 
us.nombreCompleto as nombre , count(fecha) 
as cantidad from inasistenciaEstudiante as ina 
inner join usuario as us on ina.id_estudiante = us.id_usuario
group by nombre, id_estudiante 
order by cantidad desc) as x where x.id_estudiante = v_estudiante;

-- Procedimiento que muestra la cantidad de estudiantes por cada grupo, dependiendo del periodo lectivo

create procedure CantidadDeGruposXestudianteXperiodo(v_periodo int)
  select count(id_grupo), Concat('grado -', cast(e.gradoActual as char) ,' ', us.nombreCompleto) as estudianteGrado from estudianteGrupo as eg 
  inner join estudiante as e on eg.id_estudiante = e.id_estudiante 
  inner join usuario as us on e.id_estudiante = us.id_usuario 
  inner join periodoLectivo pl on pl.id_periodo = e.periodo where pl.id_periodo = v_periodo 
  group by estudianteGrado
  order by estudianteGrado desc;

-- Procedimiento que muestra el porcentaje de hombres y mujeres en el centro educativo

create procedure porcentajeDeGeneroXperiodo()
select concat(t2.sexo, '- periodo - ',cast(t1.periodo as char)) as generoPerido, (t2.cantidad *100/t1.total) as porcentaje from 
(select e.periodo as periodo  , count(id_estudiante) as total from estudiante as e inner join usuario as u on u.id_usuario = e.id_estudiante 
group by periodo) as t1
inner join 
    (select u.sexo as sexo, e.periodo as periodo  , count(id_estudiante) as cantidad from estudiante as e inner join usuario as u on u.id_usuario = e.id_estudiante 
group by sexo, periodo) as t2 on t1.periodo = t2.periodo
group by t2.sexo, t1.periodo;

-- Procedimiento que muestra el porcentaje de estudiantes aprobados y reprobados del centro educativo

create procedure porcentajeAprobadosReprobados()
select concat('grupo - ', cast(t3.grupo as char),'- periodo - ', cast(t3.periodo as char)) as grupoPeriodo, t3.reprobado as reprobados, t4.aprobado as aprobados from 
    (select t1.id_grupo as grupo, t1.periodo as periodo, COALESCE(reprobados, 0) as reprobado  from grupo as t1 left join 
    (select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as reprobados  
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion 
    where resultado < g.notaMinima 
    group by grupo, periodo
    ) 
    as t2 on t1.id_grupo = t2.grupo and t1.periodo = t2.periodo) as t3
    inner join 
    (select t1.id_grupo as grupo, t1.periodo as periodo, COALESCE(aprobado, 0) as aprobado  from grupo as t1 left join 
    (select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as aprobado  
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion 
    where resultado >= g.notaMinima 
    group by grupo, periodo
    ) 
    as t2 on t1.id_grupo = t2.grupo and t1.periodo = t2.periodo ) as t4 on t3.grupo = t4.grupo and t3.periodo = t4.periodo;

-- Procedimiento que muestra el porcentaje de estudiantes aprobados y reprobados del centro educativo de forma individual

create procedure porcentajeAprobadosReprobadosParticular(v_periodo int)
select * from (
select t3.periodo as periodo, t3.reprobado 
as reprobados, t4.aprobado as aprobados from 
    (select t1.id_grupo as grupo, t1.periodo as periodo, 
    COALESCE(reprobados, 0) as reprobado  from grupo as t1 
    left join 
    (select g.id_grupo as grupo, g.periodo as periodo, 
    count(resultado) as reprobados  
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on 
    n.id_evaluacion = ev.id_evaluacion 
    where resultado < g.notaMinima 
    group by grupo, periodo
    ) 
    as t2 on t1.id_grupo = t2.grupo 
    and t1.periodo = t2.periodo) as t3
    inner join 
    (select t1.id_grupo as grupo, t1.periodo as periodo, 
    COALESCE(aprobado, 0) as aprobado  from grupo as t1 left join 
    (select g.id_grupo as grupo, g.periodo as periodo, 
    count(resultado) as aprobado  
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n 
    on n.id_evaluacion = ev.id_evaluacion 
    where resultado >= g.notaMinima 
    group by grupo, periodo
    ) 
    as t2 on t1.id_grupo = t2.grupo and t1.periodo = t2.periodo ) 
    as t4 on t3.grupo = t4.grupo and t3.periodo = t4.periodo
    ) as x
    where x.periodo = v_periodo;
    
-- Procedimiento que muestra los ingresos totales del centro educativo

create procedure ventasXperiodo()
select concat(cast(pl.periodo as char),' - ', cast(pl.anno as char)) as periodo, sum(cantidad) as cobros 
from cobroFactura as cf inner join matricula as m on cf.id_matricula = m.id_matricula inner join periodoLectivo pl on m.periodo = pl.id_periodo 
group by periodo ;

-- Procedimiento que muestra la cantidad de cobros y la cantidad de cobros ya facturados

create procedure cobrosVsFacturados()
select concat(cast(t1.grado as char),'-', cast(t1.periodo as char)) as gradoperiodo , round(sumacobros,2) as cobros, round(sumaFacturados,2) as facturados from 
    (select gradoActual as grado, e.periodo as periodo, COALESCE(sum(cantidad), 0) as sumacobros
    from cobroFactura as c  
    inner join matricula as m on m.id_matricula = c.id_matricula 
    inner join estudiante e  on e.id_estudiante = e.id_estudiante and m.periodo = e.periodo 
    where e.periodo = m.periodo  
    group by grado, periodo
    ) as t1 inner join 
    (select gradoActual as grado, e.periodo as periodo, COALESCE(sum(cantidad), 0) as sumaFacturados
    from cobroFactura as c  
    inner join matricula as m on m.id_matricula = c.id_matricula 
    inner join estudiante e  on e.id_estudiante = e.id_estudiante and m.periodo = e.periodo 
    where e.periodo = m.periodo and c.estado = 'pagado' 
    group by grado, periodo

    ) as t2 on t1.grado = t2.grado and t1.periodo = t2.periodo;

-- Procedimiento que muestra los 10 profesores con más aumento de salario

create procedure top10ProfesoresAumento()
select u.nombreCompleto as nombre, max(hs.salario)-min(hs.salario) as monto from historialSalarios as hs 
inner join usuario as u on u.id_usuario = hs.id_profesor 
    group by nombre 
    order by monto desc
    limit 10;

-- Procedimiento que muestra la cantidad de mensualidades y las mensualidades ya facturadas

create procedure cobrosVsFacturadosMensualidad()
select concat(cast(t1.grado as char),'-', cast(t1.periodo as char), '-', cast(t1.anno as char), ' - mes ', cast(t1.mes as char)) as gradoperiodomes , round(sumacobros,2) as cobros, 
round(sumaFacturados,2) as facturados  from 
(select gradoActual as grado, pl.periodo as periodo, pl.anno as anno , COALESCE(sum(cantidad), 0) as sumacobros, MONTH(c.fechaCobro) as mes 
    from cobroFactura as c  
    inner join matricula as m on m.id_matricula = c.id_matricula 
    inner join estudiante e  on e.id_estudiante = e.id_estudiante and m.periodo = e.periodo 
    inner join periodoLectivo pl on e.periodo = pl.id_periodo 
    where e.periodo = m.periodo  
    group by grado, periodo, anno, mes 
    ) as t1 inner join 
(select gradoActual as grado, pl.periodo as periodo, pl.anno as anno , COALESCE(sum(cantidad), 0) as sumaFacturados, MONTH(c.fechaFactura) as mes
    from cobroFactura as c  
    inner join matricula as m on m.id_matricula = c.id_matricula 
    inner join estudiante e  on e.id_estudiante = e.id_estudiante and m.periodo = e.periodo 
    inner join periodoLectivo pl on e.periodo = pl.id_periodo
    where e.periodo = m.periodo and c.estado = 'pagado' 
    group by grado, periodo, anno, mes 
    ) as t2 on t1.grado = t2.grado and t1.periodo = t2.periodo and  t1.anno = t2.anno and t1.mes = t2.mes;

-- Procedimiento que muestra los 15 grupos con más porcentaje de aprobación

create procedure top15GrupoPorcentajeAprobacion()
select concat(cast(t1.grupo as char) , '- periodo ' , cast(pl.periodo as char),'- ', cast(pl.anno as char) ) grupoperiodo, (t1.aprobado*100/t2.total) as porcentaje, us.NombreCompleto, mt.nombreMateria from 
   (select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as aprobado , g.id_profesor, g.id_materiaGrado
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion 
    where resultado >= g.notaMinima 
    group by grupo, periodo, g.id_profesor, g.id_materiaGrado) as t1
    inner join 
   ( select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as total 
    from grupo as g left join evaluacion ev on 
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion  = ev.id_evaluacion  
    group by g.id_grupo, periodo) as t2 
    
    on t1.grupo = t2.grupo and t1.periodo = t2.periodo inner join usuario as us 
    on us.id_usuario = t1.id_profesor 
    inner join materiaGrado as mt on t1.id_materiaGrado = mt.id_materiaGrado 
    inner join periodoLectivo pl on t1.periodo = pl.id_periodo 
    order by porcentaje DESC 
    limit 15;

-- Procedimiento que muestra el porcentaje de alumnos reprobados por grupo

create procedure porcentajeReprobacionXGrupo()
select t1.grupo , pl.periodo, pl.anno , (t1.reprobado*100/t2.total) as porcentaje, us.NombreCompleto, mt.nombreMateria from 
   (select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as reprobado , g.id_profesor, g.id_materiaGrado
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion 
    where resultado < g.notaMinima 
    group by grupo, periodo, g.id_profesor, g.id_materiaGrado) as t1
    inner join 
   ( select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as total 
    from grupo as g left join evaluacion ev on 
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion  
    group by g.id_grupo, periodo) as t2 
    on t1.grupo = t2.grupo and t1.periodo = t2.periodo inner join usuario as us 
    on us.id_usuario = t1.id_profesor 
    inner join materiaGrado as mt on t1.id_materiaGrado = mt.id_materiaGrado 
    inner join periodoLectivo pl on t1.periodo = pl.id_periodo 
    order by porcentaje DESC;
    
-- Procedimiento que muestra el porcentaje de alumnos reprobados por grupo de forma individual
    
create procedure porcentajeReprobacionXGrupoParticular(v_periodo int) 
select * from (select t1.grupo , pl.periodo, pl.anno , (t1.reprobado*100/t2.total) as porcentaje, us.NombreCompleto, mt.nombreMateria from 
   (select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as reprobado , g.id_profesor, g.id_materiaGrado
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion 
    where resultado < g.notaMinima 
    group by grupo, periodo, g.id_profesor, g.id_materiaGrado) as t1
    inner join 
   ( select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as total 
    from grupo as g left join evaluacion ev on 
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion  
    group by g.id_grupo, periodo) as t2 
    on t1.grupo = t2.grupo and t1.periodo = t2.periodo inner join usuario as us 
    on us.id_usuario = t1.id_profesor 
    inner join materiaGrado as mt on t1.id_materiaGrado = mt.id_materiaGrado 
    inner join periodoLectivo pl on t1.periodo = pl.id_periodo 
    order by porcentaje DESC)
    as x where x.periodo = v_periodo;

-- Procedimiento que muestra el porcentaje de alumnos aprobados por grupo

create procedure promedioAprobacionXgrupo()
select t1.grupo , pl.periodo, pl.anno , (t1.sumaaprobados/t2.total) as promedioAprobados, us.NombreCompleto, mt.nombreMateria from 
   (
    select g.id_grupo as grupo, g.periodo as periodo, sum(resultado) as sumaaprobados , g.id_profesor, g.id_materiaGrado
    from grupo as g left join evaluacion ev on
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion 
    where resultado >= g.notaMinima 
    group by grupo, periodo, g.id_profesor, g.id_materiaGrado
    ) as t1
    inner join 
   ( select g.id_grupo as grupo, g.periodo as periodo, count(resultado) as total 
    from grupo as g left join evaluacion ev on 
    g.id_grupo = ev.grupo left join nota as n on n.id_evaluacion = ev.id_evaluacion  
    where resultado >=g.notaMinima
    group by g.id_grupo, periodo) as t2 
    on t1.grupo = t2.grupo and t1.periodo = t2.periodo inner join usuario as us 
    on us.id_usuario = t1.id_profesor 
    inner join materiaGrado as mt on t1.id_materiaGrado = mt.id_materiaGrado 
    inner join periodoLectivo pl on t1.periodo = pl.id_periodo 
    order by promedioAprobados DESC;

-- Procedimiento que muestra el promedio ponderado de cada estudiante

create procedure promedioPonderadoXestudiante()
select  k1.id_estudiante , k1.promedioPonderado, k6.cantidadGrupos,  k2.gruposaprobados , k5.promedioGruposA , k3.gruposreprobados, k4.promedioGruposR from
(
	select id_estudiante, sumNotaPond/ngrupos as promedioPonderado, ngrupos as cantidadGrupos from (
	select t1.id_estudiante as id_estudiante, sum(notaponderada) as sumNotaPond, ngrupos from 
	(select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	group by  id_estudiante, id_grupo) 
	as t1 
	inner join 
	(
	select count(id_grupo) as ngrupos, id_estudiante from estudianteGrupo
	group by id_estudiante
	)
	as t2 on t1.id_estudiante = t2.id_estudiante
	group by id_estudiante, ngrupos) as ki
) as k1 inner join
( 
	select e.id_estudiante , COALESCE(aprobados,0) gruposaprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as aprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada >= notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante 
) as k2 on k1.id_estudiante = k2.id_estudiante
inner join 
(
	select e.id_estudiante , COALESCE(reprobados,0) gruposreprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as reprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada < notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante
) as k3 on k1.id_estudiante = k3.id_estudiante
inner join 
(
	select e.id_estudiante ,  COALESCE(promedioGruposR,0) as promedioGruposR from estudiante as e left join (
	select t2.id_estudiante, sumaNotaGrupoR/reprobados as promedioGruposR from 
	(select t1.id_estudiante as id_estudiante, sum(notaponderada) as sumaNotaGrupoR  from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	group by  id_estudiante, id_grupo) 
	as t1 where notaponderada < notaMinima 
	group by t1.id_estudiante) as t2 
	inner join 
	(
	select e.id_estudiante , COALESCE(reprobados,0) reprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as reprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada < notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante 
	) as t3 on t2.id_estudiante = t3.id_estudiante )as promR on e.id_estudiante = promR.id_estudiante 
) as k4 on k1.id_estudiante = k4.id_estudiante
inner join
(
	select e.id_estudiante ,  COALESCE(promedioGruposA,0) as promedioGruposA from estudiante as e left join 
	(
	select t2.id_estudiante, sumaNotaGrupoA/aprobados as promedioGruposA from 
	(select t1.id_estudiante as id_estudiante, sum(notaponderada) as sumaNotaGrupoA  from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	group by  id_estudiante, id_grupo) 
	as t1 where notaponderada >= notaMinima 
	group by t1.id_estudiante) as t2 
	inner join 
	(
	select e.id_estudiante , COALESCE(aprobados,0) aprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as aprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada >= notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante 
	) as t3 on t2.id_estudiante = t3.id_estudiante ) as promA on e.id_estudiante = promA.id_estudiante 
) as k5 on k1.id_estudiante = k5.id_estudiante
inner JOIN 
(
	select count(id_grupo) as cantidadGrupos, id_estudiante from estudianteGrupo
	group by id_estudiante
) as k6 on k1.id_estudiante = k6.id_estudiante

-- --------------------------------

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (1, '2021-01-03')

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (1, '2021-01-04')

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (1, '2021-01-05')

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (1, '2021-01-06')

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (2, '2021-01-03')

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (2, '2021-01-04')

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (2, '2021-01-05')

-- Procedimiento que cierra el periodo vigente en ese momento

CREATE PROCEDURE cierrePeriodo(
    IN  peridoIn INT)
BEGIN
    DECLARE faltantes int DEFAULT 0;
    DECLARE existentes int DEFAULT 0;
    SELECT notasFaltantes 
    INTO faltantes
    FROM (
	    SELECT count(*) as notasFaltantes FROM (
		select g.periodo , ev.grupo , ev.id_evaluacion, n.id_estudiante, COALESCE(resultado) as nota 
		from evaluacion ev inner join grupo g on ev.grupo = g.id_grupo left join nota as n on ev.id_evaluacion = n.id_evaluacion 
		where g.periodo = peridoIn 
		) as t1
		WHERE nota IS NULL
    ) as tb1;
    SELECT notasExistentes 
    INTO existentes
    FROM (
	    SELECT count(*) as notasExistentes FROM (
		select g.periodo , ev.grupo , ev.id_evaluacion, n.id_estudiante, COALESCE(resultado) as nota 
		from evaluacion ev inner join grupo g on ev.grupo = g.id_grupo left join nota as n on ev.id_evaluacion = n.id_evaluacion 
		where g.periodo = peridoIn
		) as t2
		WHERE nota IS NOT NULL
    ) as tb2;
    IF existentes <> faltantes THEN
       -- hacer update del estado de los grupos y del periodo
    		UPDATE estudiante
		SET 
		    gradoActual = gradoActual + 1
		WHERE id_estudiante IN (
		 select k3.id_estudiante from 
			(select id_estudiante, count(id_grupo) as gtotal  from (
			    select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada , g.notaMinima as notaMinima
			    from nota as n
				inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
				inner join grupo as g on ev.grupo = g.id_grupo 
				inner join materiaGrado mg on g.id_materiaGrado = mg.id_materiaGrado 
				inner join estudiante e on e.id_estudiante = n.id_estudiante and e.gradoActual = mg.grado 
				where g.periodo = 1
				group by  id_estudiante, id_grupo, g.notaMinima
			) as k1 
			group by id_estudiante) as k3 
		    left join (
		      select id_estudiante, count(id_grupo) as gaprob from (
		    	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada , g.notaMinima as notaMinima
			    from nota as n
				inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
				inner join grupo as g on ev.grupo = g.id_grupo 
				inner join materiaGrado mg on g.id_materiaGrado = mg.id_materiaGrado 
				inner join estudiante e on e.id_estudiante = n.id_estudiante and e.gradoActual = mg.grado 
				where g.periodo = 1
				group by  id_estudiante, id_grupo, g.notaMinima
		    	) as k2 where notaponderada >= notaMinima
		    	group by id_estudiante
		      ) as k4 
		      on k3.id_estudiante = k4.id_estudiante 
		      where k3.gtotal = gaprob
			);
    		UPDATE grupo
			SET estado = 'cerrado'
			WHERE periodo = peridoIn;
		UPDATE periodoLectivo 
			SET estado = 'cerrado'
			WHERE id_periodo = peridoIn;
    END IF;
END

-- ----------------------------------------------------

insert into historialSalarios (id_profesor, salario, fecha) values (21, 60000, now());
insert into historialSalarios (id_profesor, salario, fecha) values (22, 1000, now());
insert into historialSalarios (id_profesor, salario, fecha) values (23, 10000, now());
insert into historialSalarios (id_profesor, salario, fecha) values (24, 800000, now());
insert into historialSalarios (id_profesor, salario, fecha) values (25, 110000, now());
insert into historialSalarios (id_profesor, salario, fecha) values (26, 500000, now());

-- ----------------------------------------------------

insert into inasistenciaEstudiante (id_estudiante, fecha)
values (3, '2021-01-03');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (3, '2021-01-04');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (3, '2021-01-05');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (3, '2021-01-06');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-03');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-04');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-05');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-06');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-07');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-08');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-09');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-10');
insert into inasistenciaEstudiante (id_estudiante, fecha)
values (9, '2021-01-11');

-- Procedimiento que muestra el promedio ponderado de cada estudiante de forma individual

create procedure promedioPonderadoXestudianteParticular(v_estudiante int)
select  k1.id_estudiante , k1.promedioPonderado, k6.cantidadGrupos,  k2.gruposaprobados , k5.promedioGruposA , k3.gruposreprobados, k4.promedioGruposR from
(
	select id_estudiante, sumNotaPond/ngrupos as promedioPonderado, ngrupos as cantidadGrupos from (
	select t1.id_estudiante as id_estudiante, sum(notaponderada) as sumNotaPond, ngrupos from 
	(select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	where id_estudiante = v_estudiante
	group by  id_estudiante, id_grupo) 
	as t1 
	inner join 
	(
	select count(id_grupo) as ngrupos, id_estudiante from estudianteGrupo
	group by id_estudiante
	)
	as t2 on t1.id_estudiante = t2.id_estudiante
	group by id_estudiante, ngrupos) as ki
) as k1 inner join
( 
	select e.id_estudiante , COALESCE(aprobados,0) gruposaprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as aprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	where id_estudiante = v_estudiante
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada >= notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante where e.id_estudiante = v_estudiante
) as k2 on k1.id_estudiante = k2.id_estudiante
inner join 
(
	select e.id_estudiante , COALESCE(reprobados,0) gruposreprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as reprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	where id_estudiante = v_estudiante
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada < notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante where e.id_estudiante = v_estudiante 
) as k3 on k1.id_estudiante = k3.id_estudiante
inner join 
(
	select e.id_estudiante ,  COALESCE(promedioGruposR,0) as promedioGruposR from estudiante as e left join (
	select t2.id_estudiante, sumaNotaGrupoR/reprobados as promedioGruposR from 
	(select t1.id_estudiante as id_estudiante, sum(notaponderada) as sumaNotaGrupoR  from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	where id_estudiante = v_estudiante 
	group by  id_estudiante, id_grupo) 
	as t1 where notaponderada < notaMinima 
	group by t1.id_estudiante) as t2 
	inner join 
	(
	select e.id_estudiante , COALESCE(reprobados,0) reprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as reprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	where id_estudiante = v_estudiante
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada < notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante where e.id_estudiante = v_estudiante 
	) as t3 on t2.id_estudiante = t3.id_estudiante )as promR on e.id_estudiante = promR.id_estudiante 
	where e.id_estudiante = v_estudiante
) as k4 on k1.id_estudiante = k4.id_estudiante
inner join
(
	select e.id_estudiante ,  COALESCE(promedioGruposA,0) as promedioGruposA from estudiante as e left join 
	(
	select t2.id_estudiante, sumaNotaGrupoA/aprobados as promedioGruposA from 
	(select t1.id_estudiante as id_estudiante, sum(notaponderada) as sumaNotaGrupoA  from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	where id_estudiante = v_estudiante 
	group by  id_estudiante, id_grupo) 
	as t1 where notaponderada >= notaMinima 
	group by t1.id_estudiante) as t2 
	inner join 
	(
	select e.id_estudiante , COALESCE(aprobados,0) aprobados from estudiante as e 
	left join 
	(select id_estudiante, count(id_grupo) as aprobados from (
	select n.id_estudiante as id_estudiante, ev.grupo as id_grupo, sum((n.resultado *ev.porcentaje)/100) as notaponderada, g.notaMinima as notaMinima from nota as n
	inner join evaluacion as ev on n.id_evaluacion = ev.id_evaluacion 
	inner join grupo as g on g.id_grupo = ev.grupo 
	where id_estudiante = v_estudiante
	group by  id_estudiante, id_grupo
	) as tapr
	where notaponderada >= notaMinima
	group by id_estudiante
	) as apr2 on e.id_estudiante = apr2.id_estudiante where e.id_estudiante = v_estudiante 
	) as t3 on t2.id_estudiante = t3.id_estudiante ) as promA on e.id_estudiante = promA.id_estudiante 
	where e.id_estudiante = v_estudiante
) as k5 on k1.id_estudiante = k5.id_estudiante
inner JOIN 
(
	select count(id_grupo) as cantidadGrupos, id_estudiante from estudianteGrupo
	group by id_estudiante
) as k6 on k1.id_estudiante = k6.id_estudiante
