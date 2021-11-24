-- Lermith Biarreta Portillo y Adrian Herrera Segura

-- Base de datos que administra la informacion de un colegio
-- Matriculas, mensualidades,  horarios, clases, profesores, etc.

DROP DATABASE IF EXISTS matricula;
create database matricula;

use matricula;

------------------------------------------ CREACIÓN DE TABLAS --------------------------------------------------------

-- Tabla que crea un usuario generalizado en la base de datos
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

-- Tabla que se basa en la información de la tabla usuario y le añade nueva información para crear un profesor
create table profesor
(
    cedulaProfesor int,
    materiaImpartida varchar(30) NOT NULL,
    salario DECIMAL(13, 4) NOT NULL,
    PRIMARY KEY (cedulaProfesor),
    FOREIGN KEY (cedulaProfesor) REFERENCES usuario(cedula)
);

-- Tabla que define una materia para un grado en concreto
create table materiaGrado
(
    codigoMateriaGrado int NOT NULL, 
    nombreMateria varchar(30) NOT NULL,
    grado int NOT NULL CHECK (grado > 0),
    PRIMARY KEY (codigoMateriaGrado)
);

-- Tabla que se basa en la información de la tabla usuario y le añade nueva información para crear un padre
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

-- Tabla usada para inicializar un nuevo periodo lectivo dentro del centro educativo
create table periodoLectivo
(
    numeroPeriodo int NOT NULL CHECK (numeroPeriodo > 0),
    anno int NOT NULL CHECK (anno > 1999),
    fechaInicio date NOT NULL,
    fechaFinal date NOT NULL,
    estadoCurso varchar(20),
    PRIMARY KEY (numeroPeriodo, anno)
);

-- Tabla que inicializa un grupo
create table grupo
(
    codigoGrupo int NOT NULL CHECK (codigoGrupo > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cupo int NOT NULL CHECK (cupo > 0),
    materiaGrado int NOT NULL,
    notaMinima int NOT NULL CHECK (notaMinima > 0),
    nombreCurso varchar(20) NOT NULL,
    anno int NOT NULL,
    aula int NOT NULL CHECK (aula > 0),
    cedulaProfesor int,
    estado varchar(30) NOT NULL,
    PRIMARY KEY (codigoGrupo),
    FOREIGN KEY (periodo) REFERENCES periodoLectivo(numeroPeriodo),
    FOREIGN KEY (cedulaProfesor) REFERENCES profesor(cedulaProfesor),
    FOREIGN KEY (materiaGrado) REFERENCES materiaGrado(codigoMateriaGrado)
);

-- Tabla que se basa en la información de la tabla usuario y le añade nueva información para crear un estudiante
create table estudiante
(
    cedulaEstudiante int NOT NULL,
    gradosCursados int NOT NULL CHECK (gradosCursados > 0),
    periodo int NOT NULL CHECK (periodo > 0),
    cursoActual varchar(50) NOT NULL,
    estadoPeriodo varchar(20) NOT NULL,
    cedulaPadre  int NOT NULL,
    grupo int,
    PRIMARY KEY (cedulaEstudiante),
    FOREIGN KEY (cedulaEstudiante) REFERENCES usuario(cedula),
    FOREIGN KEY (cedulaPadre) REFERENCES padre(cedulaPadre),
    FOREIGN KEY (grupo) REFERENCES grupo(codigoGrupo)
);

-- Tabla usada para contar las asistencias de los estudiantes dentro de un grupo 
create table inasistenciaEstudiante
(
    cedulaEstudiante int NOT NULL,
    fecha date NOT NULL,
    PRIMARY KEY (cedulaEstudiante, fecha),
    FOREIGN KEY (cedulaEstudiante) references estudiante(cedulaEstudiante)
);

-- Tabla de posee la tabla de evaluaciones de los cursos del colegio

create table evaluacion
(
    codigoEvaluacion int NOT NULL, 
    evaluacion varchar(30) NOT NULL,
    porcentaje int NOT NULL CHECK (porcentaje BETWEEN 1 AND 100),
    grupo int,
    PRIMARY KEY (codigoEvaluacion),
    FOREIGN KEY (grupo) REFERENCES grupo(codigoGrupo)
);

-- Tabla creda para asignarle una nota a cada estudiante dentro de un curso
create table nota
(
    codigoEvaluacion int NOT NULL,
    cedulaEstudiante int NOT NULL,
    resultado int NOT NULL,
    PRIMARY KEY (codigoEvaluacion, cedulaEstudiante),
    FOREIGN KEY (codigoEvaluacion) REFERENCES evaluacion(codigoEvaluacion),
    FOREIGN KEY (cedulaEstudiante) REFERENCES estudiante(cedulaEstudiante)
);

-- Tabla creada para inicializar la matricula de un estudiante dentro del centro educativo
create table matricula
(
    cedulaEstudiante int NOT NULL CHECK (cedulaEstudiante > 0),
    periodoMatricular int NOT NULL CHECK (periodoMatricular > 0),
    anno int NOT NULL CHECK (anno > 0),
    cobrosPendientes int NOT NULL CHECK (cobrosPendientes > -1),
    montoMatricula DECIMAL(13, 4) NOT NULL,
    PRIMARY KEY (cedulaEstudiante, periodoMatricular, anno),
    FOREIGN KEY (cedulaEstudiante) REFERENCES estudiante(cedulaEstudiante),
    FOREIGN KEY (periodoMatricular, anno) REFERENCES periodoLectivo(numeroPeriodo, anno)
);

-- Tabla creada para generar una factura a un padre cuando paga las mensualidades de un estudiante
create table factura
(
    cedulaPadre int NOT NULL CHECK (cedulaPadre > 0),
    periodo int NOT NULL,
    anno int NOT NULL,
    fechaPago date NOT NULL,
    montoTotal DECIMAL(13, 4) NOT NULL,
    cedulaEstudiante int NOT NULL,
    PRIMARY KEY (cedulaPadre),
    FOREIGN KEY (cedulaEstudiante, periodo, anno) REFERENCES matricula(cedulaEstudiante, periodoMatricular, anno)
);

-- Tabla creada para mantener un historial de los Salarios de un profesor

create table historialSalarios
(
	cedulaProfesor int NOT NULL,
	salario int NOT NULL,
	fecha date NOT NULL,
	PRIMARY KEY(cedulaProfesor, fecha),
	FOREIGN KEY (cedulaProfesor) REFERENCES profesor(cedulaProfesor)
);

-- Tabla creada para generar Cobros de mensualidades

create table cobros
(
	cedulaEstudiante int NOT NULL,
	periodo int NOT NULL,
	mensualidadesPagadas int NOT NULL,
	cantidadIngresada DECIMAL(13, 4) NOT NULL,
	fecha date NOT NULL,
	anno int NOT NULL,
	PRIMARY KEY(cedulaEstudiante, fecha),
	FOREIGN KEY (cedulaEstudiante, periodo, anno) REFERENCES matricula(cedulaEstudiante, periodoMatricular, anno)
);

---------------------- CREACIÓN DE FUNCIONES Y PROCEDIMIENTOS ALMACENADOS ---------------------------------------------------

-- Función que calcula los montos pendientes de la matricula de cada estudiante a la hora de que un padre empiece el proceso de matricula

CREATE DEFINER=`root`@`localhost` TRIGGER `cobrosDeMatriculasCompletos` BEFORE INSERT ON `cobros` FOR EACH ROW update new inner join matricula on new.cedulaEstudiante = matricula.cedulaEstudiante  
           set matricula.cobrosPendientes = (matricula.cobrosPendientes - 1) 
           where matricula.cedulaEstudiante = new.cedulaEstudiante

-- Función que anota de salario de los profesores en el historial de salarios
       
CREATE DEFINER=`root`@`localhost` TRIGGER `actualizarSalarioProfesor` BEFORE INSERT ON `historialSalarios` FOR EACH ROW update new inner join profesor on new.cedulaProfesor = profesor.cedulaProfesor  
           set profesor.salario = new.salario
           where new.cedulaProfesor = profesor.cedulaProfesor

-- Función permite editar el salario de los profesores a uno diferente

CREATE DEFINER=`root`@`localhost` PROCEDURE `matricula`.`aumentoProfesores`()
BEGIN

	select CAST(hs.cedulaProfesor AS CHAR) as cedula, max(hs.salario)-min(hs.salario) as aumento from historialSalarios2 as hs 

	group by cedulaProfesor order by cedulaProfesor
	limit 10;
END

-- Función que muestra la cantidad de estudiantes matriculados en total, por periodo y por grupo.

CREATE DEFINER=`root`@`localhost` PROCEDURE `matricula`.`CantidadEstudiantePeriodoGrupo`()
BEGIN
	select count(distinct m.cedulaEstudiante) as num, concat(cast(m.periodoMatricular as char), " - ",
	cast(g.codigoGrupo as char)) as pg from matricula as m inner join grupo as g where m.periodoMatricular = g.periodo 
	group by pg;
END	

-- Función que muestra el promedio total de rendimiento de los estudiantes de cada grupo, junto con el nombre del profesor

CREATE DEFINER=`root`@`localhost` PROCEDURE `matricula`.`promedioXGrupoXProfesor`()
BEGIN

	select AVG(n.resultado) as promedio, concat(CAST(ev.grupo AS CHAR), " - ", CAST(p.cedulaProfesor AS CHAR)) as gp
	from nota as n inner join evaluacion as ev inner join grupo as g 
	inner join profesor as p 
	where n.codigoEvaluacion = ev.codigoEvaluacion 
	and ev.grupo = g.codigoGrupo 
	and g.cedulaProfesor = p.cedulaProfesor
	group by gp;

END	

-- Función que muestra los 10 padres con más pagos pendientes en el centro educativo.

CREATE DEFINER=`root`@`localhost` PROCEDURE `matricula`.`Top10PadresDeuda`()
BEGIN

	select us.nombreCompleto as padre, sum(t1.deuda) as deuda from 
	(select d.cedulaEstudiante as cedulaEstudiante, (d.pendiente - COALESCE(p.pagado, 0 )) as deuda from 
	(select cedulaEstudiante, sum(montoMatricula)as pendiente from matricula
	group by cedulaEstudiante ) as d
	LEFT JOIN 
	(select sum(cantidadIngresada) as pagado, cedulaEstudiante from cobros 
	group by cedulaEstudiante) as p
	on p.cedulaEstudiante = d.cedulaEstudiante) as t1 inner join estudiante as p on p.cedulaEstudiante= t1.cedulaEstudiante
	inner join usuario as us on p.cedulaPadre = us.cedula 
	group by padre 
	order by deuda desc
	limit 10;

END

-- Función que muestra la cantidad de estudiantes aprobados y reprobados de un curso una vez terminado un curso.

CREATE PROCEDURE cantidadAprobadosReprobadosGP()
BEGIN

	select concat(cast(t3.grupo as char),'-', cast(t3.periodo as char)) as gp, t3.reprobado, t4.aprobado from 
	(select t1.codigoGrupo as grupo, t1.periodo as periodo, COALESCE(reprobados, 0) as reprobado  from grupo as t1 left join 
	(select g.codigoGrupo as grupo, g.periodo as periodo, count(resultado) as reprobados  
	from grupo as g left join evaluacion ev on
	g.codigoGrupo = ev.grupo left join nota as n on n.codigoEvaluacion = ev.codigoEvaluacion 
	where resultado < g.notaMinima 
	group by grupo, periodo
	) 
	as t2 on t1.codigoGrupo = t2.grupo and t1.periodo = t2.periodo) as t3
	inner join 
	(select t1.codigoGrupo as grupo, t1.periodo as periodo, COALESCE(aprobado, 0) as aprobado  from grupo as t1 left join 
	(select g.codigoGrupo as grupo, g.periodo as periodo, count(resultado) as aprobado  
	from grupo as g left join evaluacion ev on
	g.codigoGrupo = ev.grupo left join nota as n on n.codigoEvaluacion = ev.codigoEvaluacion 
	where resultado >= g.notaMinima 
	group by grupo, periodo
	) 
	as t2 on t1.codigoGrupo = t2.grupo and t1.periodo = t2.periodo ) as t4 on t3.grupo = t4.grupo and t3.periodo = t4.periodo;

END

--Función que inserta el primer salario de los profesores en la base de datos y en el historial de salarios

CREATE DEFINER=root@localhost TRIGGER primerSalario 
BEFORE INSERT ON profesor FOR EACH ROW insert into historialSalarios2 (cedulaProfesor, salario, fecha) 
values (new.cedulaProfesor, new.salario, now())

-- Función que compara la cantidad de cobros pendientes y los facturados

CREATE DEFINER=root@localhost PROCEDURE matricula.cobrosVsFacturados()
BEGIN

    select concat(cast(t1.grado as char),'-', cast(t1.periodo as char)) as gradoperiodo , sumacobros as cobros, sumaFacturados as facturados from 
    (select gradosCursados as grado, e.periodo as periodo, COALESCE(sum(cantidadIngresada),0) as sumacobros
    from estudiante as e left join cobros as c on e.cedulaEstudiante = c.cedulaEstudiante and e.periodo = c.periodo 
    group by grado, periodo) as t1 inner join 

    (select gradosCursados as grado, e.periodo as periodo, COALESCE(sum(montoTotal), 0) as sumaFacturados
    from estudiante as e left join factura as c on e.cedulaEstudiante = c.cedulaEstudiante and e.periodo = c.periodo 
    group by grado, periodo) as t2 on t1.grado = t2.grado and t1.periodo = t2.periodo;

END

--Función que calcula la cantidad de ingresos monetarios que ha tenido el centro educativo por periodo

CREATE DEFINER=root@localhost PROCEDURE matricula.ventasCobrosPeriodo()
BEGIN

    select concat(cast(periodo as char),'-', cast(anno as char)) as gp, sum(cantidadIngresada) as          cobros from cobros
    group by periodo, anno;

END

-- Función que imprime los 15 grupos con mayor porcentaje de aprobación

CREATE DEFINER=root@localhost PROCEDURE matricula.top15GrupoPorcentajeAprobacion()
BEGIN

   select t1.grupo , t1.periodo , (t1.aprobado*100/t2.total) as porcentaje, us.NombreCompleto, mt.nombreMateria from 
   (select g.codigoGrupo as grupo, g.periodo as periodo, count(resultado) as aprobado , g.cedulaProfesor, g.materiaGrado
    from grupo as g left join evaluacion ev on
    g.codigoGrupo = ev.grupo left join nota as n on n.codigoEvaluacion = ev.codigoEvaluacion 
    where resultado >= g.notaMinima 
    group by grupo, periodo, g.cedulaProfesor, g.materiaGrado) as t1
    inner join 
   ( select g.codigoGrupo as grupo, g.periodo as periodo, count(resultado) as total 
    from grupo as g left join evaluacion ev on 
    g.codigoGrupo = ev.grupo left join nota as n on n.codigoEvaluacion = ev.codigoEvaluacion
    group by g.codigoGrupo, periodo) as t2 
    on t1.grupo = t2.grupo and t1.periodo = t2.periodo inner join usuario as us 
    on us.cedula = t1.cedulaProfesor 
    inner join materiaGrado as mt on t1.materiaGrado = mt.codigoMateriaGrado 
    order by porcentaje DESC 
    limit 15;

END

-- Función que imprime el porcentaje de reprobación de cada grupo

CREATE DEFINER=root@localhost PROCEDURE matricula.porcentajeReprobacionGrupo()
BEGIN

   select t1.grupo , t1.periodo , (t1.reprobado*100/t2.total) as porcentaje, us.NombreCompleto, mt.nombreMateria from 
   (select g.codigoGrupo as grupo, g.periodo as periodo, count(resultado) as reprobado , g.cedulaProfesor, g.materiaGrado
    from grupo as g left join evaluacion ev on
    g.codigoGrupo = ev.grupo left join nota as n on n.codigoEvaluacion = ev.codigoEvaluacion 
    where resultado < g.notaMinima 
    group by grupo, periodo, g.cedulaProfesor, g.materiaGrado) as t1
    inner join 
   ( select g.codigoGrupo as grupo, g.periodo as periodo, count(resultado) as total 
    from grupo as g left join evaluacion ev on 
    g.codigoGrupo = ev.grupo left join nota as n on n.codigoEvaluacion = ev.codigoEvaluacion
    group by g.codigoGrupo, periodo) as t2 
    on t1.grupo = t2.grupo and t1.periodo = t2.periodo inner join usuario as us 
    on us.cedula = t1.cedulaProfesor 
    inner join materiaGrado as mt on t1.materiaGrado = mt.codigoMateriaGrado 
    order by porcentaje DESC;

END