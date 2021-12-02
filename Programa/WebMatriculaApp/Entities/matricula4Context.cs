using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebMatriculaApp.Entities
{
    public partial class matricula4Context : DbContext
    {

        public matricula4Context(DbContextOptions<matricula4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CobroFactura> CobroFacturas { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteGrupo> EstudianteGrupos { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
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
        public virtual DbSet<PromedioxProfesorXGrupo> PromedioxProfesorXGrupos { get; set; } // Sirve
        public virtual DbSet<GrupoPeriodo> GrupoPeriodos { get; set; } // Sirve
        public virtual DbSet<Ingreso> Ingresos { get; set; } // Sirve
        public virtual DbSet<AprobadoReprobado> AprobadoReprobados { get; set; } // Sirve  
        public virtual DbSet<PGenero> PGeneros { get; set; }  // Sirve
        public virtual DbSet<Reprobacion> Reprobacions { get; set; } // Sirve 
        public virtual DbSet<Aprobacion> Aprobacions { get; set; }  // Sirve
        public virtual DbSet<Ausencia> Ausencias { get; set; }  // Sirve
        public virtual DbSet<Deuda> Deudas { get; set; }  // Sirve
        public virtual DbSet<Ponderado> Ponderados { get; set; }  // 
        public virtual DbSet<GrupoAprobacion> GrupoAprobacions { get; set; }  // Sirve
        public virtual DbSet<Venta> Ventas { get; set; } // Sirve
        public virtual DbSet<Aumento> Aumentos { get; set; } // Sirve
        public virtual DbSet<CobroVSFactura> CobroVSFacturas { get; set; } // Sirve
        public virtual DbSet<Mes> Mess { get; set; } // Sirve
        public virtual DbSet<AusenciaParticular> AusenciaParticulars { get; set; } // Sirve
        public virtual DbSet<CantEstudiante> CantEstudiantes { get; set; } // Sirve
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=matricula4", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<CobroFactura>(entity =>
            {
                entity.HasKey(e => e.IdCobroFactura)
                    .HasName("PRIMARY");

                entity.ToTable("cobroFactura");

                entity.HasIndex(e => e.IdPadre, "id_padre");

                entity.HasIndex(e => new { e.IdMatricula, e.NumeroMensualidad }, "uc_cobroFactura")
                    .IsUnique();

                entity.Property(e => e.IdCobroFactura).HasColumnName("id_cobroFactura");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaCobro)
                    .HasColumnType("date")
                    .HasColumnName("fechaCobro");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("date")
                    .HasColumnName("fechaFactura");

                entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");

                entity.Property(e => e.NumeroMensualidad).HasColumnName("numeroMensualidad");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.CobroFacturas)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cobrofactura_ibfk_1");

                entity.HasOne(d => d.IdPadreNavigation)
                    .WithMany(p => p.CobroFacturas)
                    .HasForeignKey(d => d.IdPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cobrofactura_ibfk_2");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PRIMARY");

                entity.ToTable("estudiante");

                entity.HasIndex(e => e.IdPadre, "id_padre");

                entity.Property(e => e.IdEstudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("id_estudiante");

                entity.Property(e => e.GradoActual).HasColumnName("gradoActual");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithOne(p => p.Estudiante)
                    .HasForeignKey<Estudiante>(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiante_ibfk_1");

                entity.HasOne(d => d.IdPadreNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiante_ibfk_2");
            });

            modelBuilder.Entity<EstudianteGrupo>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdGrupo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("estudianteGrupo");

                entity.HasIndex(e => e.IdGrupo, "id_grupo");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.EstudianteGrupos)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiantegrupo_ibfk_1");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.EstudianteGrupos)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiantegrupo_ibfk_2");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.HasKey(e => e.IdEvaluacion)
                    .HasName("PRIMARY");

                entity.ToTable("evaluacion");

                entity.HasIndex(e => e.Grupo, "grupo");

                entity.Property(e => e.IdEvaluacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_evaluacion");

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

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("grupo");

                entity.HasIndex(e => e.IdMateriaGrado, "id_materiaGrado");

                entity.HasIndex(e => e.IdProfesor, "id_profesor");

                entity.HasIndex(e => e.Periodo, "periodo");

                entity.Property(e => e.IdGrupo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_grupo");

                entity.Property(e => e.Aula).HasColumnName("aula");

                entity.Property(e => e.Cupo).HasColumnName("cupo");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("estado");

                entity.Property(e => e.IdMateriaGrado).HasColumnName("id_materiaGrado");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.NotaMinima).HasColumnName("notaMinima");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.IdMateriaGradoNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdMateriaGrado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupo_ibfk_3");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("grupo_ibfk_2");

                entity.HasOne(d => d.PeriodoNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupo_ibfk_1");
            });

            modelBuilder.Entity<HistorialSalario>(entity =>
            {
                entity.HasKey(e => new { e.IdProfesor, e.Fecha })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("historialSalarios");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.HistorialSalarios)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historialsalarios_ibfk_1");
            });

            modelBuilder.Entity<InasistenciaEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdInasistenciaE)
                    .HasName("PRIMARY");

                entity.ToTable("inasistenciaEstudiante");

                entity.HasIndex(e => new { e.IdEstudiante, e.Fecha }, "uc_inasistenciaEstudiante")
                    .IsUnique();

                entity.Property(e => e.IdInasistenciaE).HasColumnName("id_inasistenciaE");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.InasistenciaEstudiantes)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inasistenciaestudiante_ibfk_1");
            });

            modelBuilder.Entity<MateriaGrado>(entity =>
            {
                entity.HasKey(e => e.IdMateriaGrado)
                    .HasName("PRIMARY");

                entity.ToTable("materiaGrado");

                entity.Property(e => e.IdMateriaGrado)
                    .ValueGeneratedNever()
                    .HasColumnName("id_materiaGrado");

                entity.Property(e => e.Grado).HasColumnName("grado");

                entity.Property(e => e.NombreMateria)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombreMateria");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PRIMARY");

                entity.ToTable("matricula");

                entity.HasIndex(e => e.Periodo, "periodo");

                entity.HasIndex(e => new { e.IdEstudiante, e.Periodo }, "uc_matricula")
                    .IsUnique();

                entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");

                entity.Property(e => e.CobrosPendientes).HasColumnName("cobrosPendientes");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.MontoMatricula)
                    .HasPrecision(13, 4)
                    .HasColumnName("montoMatricula");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matricula_ibfk_1");

                entity.HasOne(d => d.PeriodoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matricula_ibfk_2");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => e.IdNota)
                    .HasName("PRIMARY");

                entity.ToTable("nota");

                entity.HasIndex(e => e.IdEstudiante, "id_estudiante");

                entity.HasIndex(e => new { e.IdEvaluacion, e.IdEstudiante }, "uc_nota")
                    .IsUnique();

                entity.Property(e => e.IdNota).HasColumnName("id_nota");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdEvaluacion).HasColumnName("id_evaluacion");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nota_ibfk_2");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nota_ibfk_1");
            });

            modelBuilder.Entity<Padre>(entity =>
            {
                entity.HasKey(e => e.IdPadre)
                    .HasName("PRIMARY");

                entity.ToTable("padre");

                entity.Property(e => e.IdPadre)
                    .ValueGeneratedNever()
                    .HasColumnName("id_padre");

                entity.Property(e => e.Conyugue)
                    .HasMaxLength(60)
                    .HasColumnName("conyugue");

                entity.Property(e => e.Profesion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("profesion");

                entity.Property(e => e.TelefonoConyugue)
                    .HasMaxLength(8)
                    .HasColumnName("telefonoConyugue");

                entity.HasOne(d => d.IdPadreNavigation)
                    .WithOne(p => p.Padre)
                    .HasForeignKey<Padre>(d => d.IdPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("padre_ibfk_1");
            });

            modelBuilder.Entity<PeriodoLectivo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PRIMARY");

                entity.ToTable("periodoLectivo");

                entity.HasIndex(e => new { e.Periodo, e.Anno }, "uc_periodo")
                    .IsUnique();

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Periodo).HasColumnName("periodo");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PRIMARY");

                entity.ToTable("profesor");

                entity.HasIndex(e => e.IdMateriaGrado, "id_materiaGrado");

                entity.Property(e => e.IdProfesor)
                    .ValueGeneratedNever()
                    .HasColumnName("id_profesor");

                entity.Property(e => e.IdMateriaGrado).HasColumnName("id_materiaGrado");

                entity.Property(e => e.Salario)
                    .HasPrecision(13, 4)
                    .HasColumnName("salario");

                entity.HasOne(d => d.IdMateriaGradoNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdMateriaGrado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesor_ibfk_2");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithOne(p => p.Profesor)
                    .HasForeignKey<Profesor>(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesor_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Cedula, "uc_usuario")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(14)
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
