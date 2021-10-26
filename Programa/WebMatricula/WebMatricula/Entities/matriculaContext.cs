using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebMatricula.Entities
{
    public partial class matriculaContext : DbContext
    {
        public matriculaContext(DbContextOptions<matriculaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Evaluacione> Evaluaciones { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<HorarioClase> HorarioClases { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Padre> Padres { get; set; }
        public virtual DbSet<PeriodoLectivo> PeriodoLectivos { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=192.168.64.2;port=3306;user=username;password=password;database=matricula", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.CedulaEstudiante)
                    .HasName("PRIMARY");

                entity.ToTable("estudiante");

                entity.HasIndex(e => e.Grupo, "grupo");

                entity.Property(e => e.CedulaEstudiante)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaEstudiante");

                entity.Property(e => e.CursoActual)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cursoActual");

                entity.Property(e => e.EstadoPeriodo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("estadoPeriodo");

                entity.Property(e => e.GradosCursados)
                    .HasColumnType("int(11)")
                    .HasColumnName("gradosCursados");

                entity.Property(e => e.Grupo)
                    .HasColumnType("int(11)")
                    .HasColumnName("grupo");

                entity.Property(e => e.Periodo)
                    .HasColumnType("int(11)")
                    .HasColumnName("periodo");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithOne(p => p.Estudiante)
                    .HasForeignKey<Estudiante>(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiante_ibfk_1");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Grupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiante_ibfk_2");
            });

            modelBuilder.Entity<Evaluacione>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("evaluaciones");

                entity.HasIndex(e => e.Curso, "curso");

                entity.Property(e => e.Curso)
                    .HasColumnType("int(11)")
                    .HasColumnName("curso");

                entity.Property(e => e.Evaluacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("evaluacion");

                entity.Property(e => e.Porcentaje)
                    .HasColumnType("int(11)")
                    .HasColumnName("porcentaje");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("evaluaciones_ibfk_1");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.CedulaPadre)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.HasIndex(e => new { e.CedulaEstudiante, e.Periodo, e.Ano }, "cedulaEstudiante");

                entity.Property(e => e.CedulaPadre)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaPadre");

                entity.Property(e => e.Ano)
                    .HasColumnType("int(11)")
                    .HasColumnName("ano");

                entity.Property(e => e.CedulaEstudiante)
                    .HasColumnType("int(11)")
                    .HasColumnName("cedulaEstudiante");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("date")
                    .HasColumnName("fechaPago");

                entity.Property(e => e.MontoTotal)
                    .HasPrecision(13, 4)
                    .HasColumnName("montoTotal");

                entity.Property(e => e.Periodo)
                    .HasColumnType("int(11)")
                    .HasColumnName("periodo");

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => new { d.CedulaEstudiante, d.Periodo, d.Ano })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_ibfk_1");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.CodigoGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("grupo");

                entity.HasIndex(e => e.CedulaProfesor, "cedulaProfesor");

                entity.Property(e => e.CodigoGrupo)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("codigoGrupo");

                entity.Property(e => e.CedulaProfesor)
                    .HasColumnType("int(11)")
                    .HasColumnName("cedulaProfesor");

                entity.Property(e => e.Cupo)
                    .HasColumnType("int(11)")
                    .HasColumnName("cupo");

                entity.Property(e => e.Grado)
                    .HasColumnType("int(11)")
                    .HasColumnName("grado");

                entity.Property(e => e.Materia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("materia");

                entity.Property(e => e.NotaMinima)
                    .HasColumnType("int(11)")
                    .HasColumnName("notaMinima");

                entity.Property(e => e.Periodo)
                    .HasColumnType("int(11)")
                    .HasColumnName("periodo");

                entity.Property(e => e.Profesor)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("profesor");

                entity.HasOne(d => d.CedulaProfesorNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.CedulaProfesor)
                    .HasConstraintName("grupo_ibfk_1");
            });

            modelBuilder.Entity<HorarioClase>(entity =>
            {
                entity.HasKey(e => e.CodigoCurso)
                    .HasName("PRIMARY");

                entity.ToTable("horarioClases");

                entity.HasIndex(e => new { e.PeriodoActual, e.Ano }, "periodoActual");

                entity.HasIndex(e => e.Profesor, "profesor");

                entity.Property(e => e.CodigoCurso)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ano)
                    .HasColumnType("int(11)")
                    .HasColumnName("ano");

                entity.Property(e => e.Aula)
                    .HasColumnType("int(11)")
                    .HasColumnName("aula");

                entity.Property(e => e.NombreCurso)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PeriodoActual)
                    .HasColumnType("int(11)")
                    .HasColumnName("periodoActual");

                entity.Property(e => e.Profesor)
                    .HasColumnType("int(11)")
                    .HasColumnName("profesor");

                entity.HasOne(d => d.ProfesorNavigation)
                    .WithMany(p => p.HorarioClases)
                    .HasForeignKey(d => d.Profesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("horarioClases_ibfk_2");

                entity.HasOne(d => d.PeriodoLectivo)
                    .WithMany(p => p.HorarioClases)
                    .HasForeignKey(d => new { d.PeriodoActual, d.Ano })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("horarioClases_ibfk_1");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => new { e.CedulaEstudiante, e.PeriodoMatricular, e.Ano })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("matricula");

                entity.HasIndex(e => e.CedulaPadre, "cedulaPadre");

                entity.Property(e => e.CedulaEstudiante)
                    .HasColumnType("int(11)")
                    .HasColumnName("cedulaEstudiante");

                entity.Property(e => e.PeriodoMatricular)
                    .HasColumnType("int(11)")
                    .HasColumnName("periodoMatricular");

                entity.Property(e => e.Ano)
                    .HasColumnType("int(11)")
                    .HasColumnName("ano");

                entity.Property(e => e.CedulaPadre)
                    .HasColumnType("int(11)")
                    .HasColumnName("cedulaPadre");

                entity.Property(e => e.CobrosPendientes)
                    .HasColumnType("int(11)")
                    .HasColumnName("cobrosPendientes");

                entity.Property(e => e.MontoMatricula)
                    .HasPrecision(13, 4)
                    .HasColumnName("montoMatricula");

                entity.Property(e => e.ProfesionPadre)
                    .HasMaxLength(30)
                    .HasColumnName("profesionPadre");

                entity.HasOne(d => d.CedulaPadreNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.CedulaPadre)
                    .HasConstraintName("matricula_ibfk_1");
            });

            modelBuilder.Entity<Padre>(entity =>
            {
                entity.HasKey(e => e.CedulaPadre)
                    .HasName("PRIMARY");

                entity.ToTable("padre");

                entity.Property(e => e.CedulaPadre)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("cedulaPadre");

                entity.Property(e => e.Conyugue)
                    .HasMaxLength(60)
                    .HasColumnName("conyugue");

                entity.Property(e => e.CostoMensualidad)
                    .HasPrecision(13, 4)
                    .HasColumnName("costoMensualidad");

                entity.Property(e => e.PagosRealizados)
                    .HasColumnType("int(11)")
                    .HasColumnName("pagosRealizados");

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
                entity.HasKey(e => new { e.NumeroPeriodo, e.Ano })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("periodoLectivo");

                entity.HasIndex(e => e.CedulaEstudiante, "cedulaEstudiante");

                entity.Property(e => e.NumeroPeriodo)
                    .HasColumnType("int(11)")
                    .HasColumnName("numeroPeriodo");

                entity.Property(e => e.Ano)
                    .HasColumnType("int(11)")
                    .HasColumnName("ano");

                entity.Property(e => e.CedulaEstudiante)
                    .HasColumnType("int(11)")
                    .HasColumnName("cedulaEstudiante");

                entity.Property(e => e.CursoCerrado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cursoCerrado");

                entity.Property(e => e.CursoPendiente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cursoPendiente");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithMany(p => p.PeriodoLectivos)
                    .HasForeignKey(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("periodoLectivo_ibfk_1");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.CedulaProfesor)
                    .HasName("PRIMARY");

                entity.ToTable("profesor");

                entity.Property(e => e.CedulaProfesor)
                    .HasColumnType("int(11)")
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
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("cedula");

                entity.Property(e => e.Edad)
                    .HasColumnType("int(11)")
                    .HasColumnName("edad");

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
