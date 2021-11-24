using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebMatriculaNew.Entities
{
    public partial class matriculaContext : DbContext
    {
       /* public matriculaContext()
        {
        }*/

        public matriculaContext(DbContextOptions<matriculaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cobro> Cobros { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<HistorialSalario> HistorialSalarios { get; set; }
        public virtual DbSet<InasistenciaEstudiante> InasistenciaEstudiantes { get; set; }
        public virtual DbSet<MateriaGrado> MateriaGrados { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Notum> Nota { get; set; }
        public virtual DbSet<Padre> Padres { get; set; }
        public virtual DbSet<PeriodoLectivo> PeriodoLectivos { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<PromedioXGrupoXProfesor> PromedioXGrupoXProfesors { get; set; }
        public virtual DbSet<AumentoProfesores> AumentoProfesoress { get; set; }
        public virtual DbSet<CantidadEstudiante> CantidadEstudiantes { get; set; }
        public virtual DbSet<Top10Padre> Top10Padres { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<CantGrupo> CantGrupos { get; set; }
        public virtual DbSet<EstudianteAusente> EstudianteAusentes { get; set; }
        public virtual DbSet<PorcentajeGenero> PorcentajeGeneros { get; set; }
        public virtual DbSet<AprobadoReprobado> AprobadoReprobados { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<CobroFacturado> CobroFacturados { get; set; }
        public virtual DbSet<Mensualidad> Mensualidads { get; set; }
        public virtual DbSet<Top15Grupo> Top15Grupos { get; set; }
        public virtual DbSet<ReprobacionGrupo> ReprobacionGrupos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=matricula", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Cobro>(entity =>
            {
                entity.HasKey(e => new { e.CedulaEstudiante, e.Fecha })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("cobros");

                entity.HasIndex(e => new { e.CedulaEstudiante, e.Periodo, e.Anno }, "cedulaEstudiante");

                entity.Property(e => e.CedulaEstudiante).HasColumnName("cedulaEstudiante");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.CantidadIngresada)
                    .HasPrecision(13, 4)
                    .HasColumnName("cantidadIngresada");

                entity.Property(e => e.MensualidadesPagadas).HasColumnName("mensualidadesPagadas");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Cobros)
                    .HasForeignKey(d => new { d.CedulaEstudiante, d.Periodo, d.Anno })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cobros_ibfk_1");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.CedulaEstudiante)
                    .HasName("PRIMARY");

                entity.ToTable("estudiante");

                entity.HasIndex(e => e.CedulaPadre, "cedulaPadre");

                entity.HasIndex(e => e.Grupo, "grupo");

                entity.Property(e => e.CedulaEstudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaEstudiante");

                entity.Property(e => e.CedulaPadre).HasColumnName("cedulaPadre");

                entity.Property(e => e.CursoActual)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cursoActual");

                entity.Property(e => e.EstadoPeriodo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("estadoPeriodo");

                entity.Property(e => e.GradosCursados).HasColumnName("gradosCursados");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithOne(p => p.Estudiante)
                    .HasForeignKey<Estudiante>(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiante_ibfk_1");

                entity.HasOne(d => d.CedulaPadreNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.CedulaPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiante_ibfk_2");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Grupo)
                    .HasConstraintName("estudiante_ibfk_3");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.HasKey(e => e.CodigoEvaluacion)
                    .HasName("PRIMARY");

                entity.ToTable("evaluacion");

                entity.HasIndex(e => e.Grupo, "grupo");

                entity.Property(e => e.CodigoEvaluacion)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoEvaluacion");

                entity.Property(e => e.Evaluacion1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("evaluacion");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.Grupo)
                    .HasConstraintName("evaluacion_ibfk_1");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.CedulaPadre)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.HasIndex(e => new { e.CedulaEstudiante, e.Periodo, e.Anno }, "cedulaEstudiante");

                entity.Property(e => e.CedulaPadre)
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaPadre");

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.CedulaEstudiante).HasColumnName("cedulaEstudiante");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("date")
                    .HasColumnName("fechaPago");

                entity.Property(e => e.MontoTotal)
                    .HasPrecision(13, 4)
                    .HasColumnName("montoTotal");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => new { d.CedulaEstudiante, d.Periodo, d.Anno })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_ibfk_1");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.CodigoGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("grupo");

                entity.HasIndex(e => e.CedulaProfesor, "cedulaProfesor");

                entity.HasIndex(e => e.MateriaGrado, "materiaGrado");

                entity.HasIndex(e => e.Periodo, "periodo");

                entity.Property(e => e.CodigoGrupo)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoGrupo");

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.Aula).HasColumnName("aula");

                entity.Property(e => e.CedulaProfesor).HasColumnName("cedulaProfesor");

                entity.Property(e => e.Cupo).HasColumnName("cupo");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("estado");

                entity.Property(e => e.MateriaGrado).HasColumnName("materiaGrado");

                entity.Property(e => e.NombreCurso)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombreCurso");

                entity.Property(e => e.NotaMinima).HasColumnName("notaMinima");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.CedulaProfesorNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.CedulaProfesor)
                    .HasConstraintName("grupo_ibfk_2");

                entity.HasOne(d => d.MateriaGradoNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.MateriaGrado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupo_ibfk_3");
            });

            modelBuilder.Entity<HistorialSalario>(entity =>
            {
                entity.HasKey(e => new { e.CedulaProfesor, e.Fecha })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("historialSalarios");

                entity.Property(e => e.CedulaProfesor).HasColumnName("cedulaProfesor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.HasOne(d => d.CedulaProfesorNavigation)
                    .WithMany(p => p.HistorialSalarios)
                    .HasForeignKey(d => d.CedulaProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historialsalarios_ibfk_1");
            });

            modelBuilder.Entity<InasistenciaEstudiante>(entity =>
            {
                entity.HasKey(e => new { e.CedulaEstudiante, e.Fecha })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("inasistenciaEstudiante");

                entity.Property(e => e.CedulaEstudiante).HasColumnName("cedulaEstudiante");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithMany(p => p.InasistenciaEstudiantes)
                    .HasForeignKey(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inasistenciaestudiante_ibfk_1");
            });

            modelBuilder.Entity<MateriaGrado>(entity =>
            {
                entity.HasKey(e => e.CodigoMateriaGrado)
                    .HasName("PRIMARY");

                entity.ToTable("materiaGrado");

                entity.Property(e => e.CodigoMateriaGrado)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoMateriaGrado");

                entity.Property(e => e.Grado).HasColumnName("grado");

                entity.Property(e => e.NombreMateria)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombreMateria");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => new { e.CedulaEstudiante, e.PeriodoMatricular, e.Anno })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("matricula");

                entity.HasIndex(e => new { e.PeriodoMatricular, e.Anno }, "periodoMatricular");

                entity.Property(e => e.CedulaEstudiante).HasColumnName("cedulaEstudiante");

                entity.Property(e => e.PeriodoMatricular).HasColumnName("periodoMatricular");

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.CobrosPendientes).HasColumnName("cobrosPendientes");

                entity.Property(e => e.MontoMatricula)
                    .HasPrecision(13, 4)
                    .HasColumnName("montoMatricula");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matricula_ibfk_1");

                entity.HasOne(d => d.PeriodoLectivo)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => new { d.PeriodoMatricular, d.Anno })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matricula_ibfk_2");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEvaluacion, e.CedulaEstudiante })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("nota");

                entity.HasIndex(e => e.CedulaEstudiante, "cedulaEstudiante");

                entity.Property(e => e.CodigoEvaluacion).HasColumnName("codigoEvaluacion");

                entity.Property(e => e.CedulaEstudiante).HasColumnName("cedulaEstudiante");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nota_ibfk_2");

                entity.HasOne(d => d.CodigoEvaluacionNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.CodigoEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nota_ibfk_1");
            });

            modelBuilder.Entity<Padre>(entity =>
            {
                entity.HasKey(e => e.CedulaPadre)
                    .HasName("PRIMARY");

                entity.ToTable("padre");

                entity.Property(e => e.CedulaPadre)
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaPadre");

                entity.Property(e => e.Conyugue)
                    .HasMaxLength(60)
                    .HasColumnName("conyugue");

                entity.Property(e => e.CostoMensualidad)
                    .HasPrecision(13, 4)
                    .HasColumnName("costoMensualidad");

                entity.Property(e => e.PagosRealizados).HasColumnName("pagosRealizados");

                entity.Property(e => e.Profesion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("profesion");

                entity.Property(e => e.TelefonoConyugue)
                    .HasMaxLength(8)
                    .HasColumnName("telefonoConyugue");

                entity.HasOne(d => d.CedulaPadreNavigation)
                    .WithOne(p => p.Padre)
                    .HasForeignKey<Padre>(d => d.CedulaPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("padre_ibfk_1");
            });

            modelBuilder.Entity<PeriodoLectivo>(entity =>
            {
                entity.HasKey(e => new { e.NumeroPeriodo, e.Anno })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("periodoLectivo");

                entity.Property(e => e.NumeroPeriodo).HasColumnName("numeroPeriodo");

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.EstadoCurso)
                    .HasMaxLength(20)
                    .HasColumnName("estadoCurso");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.CedulaProfesor)
                    .HasName("PRIMARY");

                entity.ToTable("profesor");

                entity.Property(e => e.CedulaProfesor)
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaProfesor");

                entity.Property(e => e.MateriaImpartida)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("materiaImpartida");

                entity.Property(e => e.Salario)
                    .HasPrecision(13, 4)
                    .HasColumnName("salario");

                entity.HasOne(d => d.CedulaProfesorNavigation)
                    .WithOne(p => p.Profesor)
                    .HasForeignKey<Profesor>(d => d.CedulaProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesor_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.Cedula)
                    .ValueGeneratedNever()
                    .HasColumnName("cedula");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("provincia");

                entity.Property(e => e.Residencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("residencia");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
