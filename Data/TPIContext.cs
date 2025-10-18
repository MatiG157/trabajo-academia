using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class TPIContext : DbContext
    {
        public TPIContext(DbContextOptions<TPIContext> options): base(options)
        {
        }

        // Constructor sin parámetros para que EF pueda instanciar en tiempo de diseño
        

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<AlumnoInscripcion> AlumnosInscripciones { get; set; }

        public TPIContext()
        {
            this.Database.EnsureCreated();
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad);

                entity.Property(e => e.IdEspecialidad)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdEspecialidad)
                   .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(360);


                entity.HasData(new
                {
                    IdEspecialidad = 1,
                    Descripcion = "Especialidad"
                });

            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.IdPlan);

                entity.Property(e => e.IdPlan)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdPlan)
                   .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(360);

                //relacion con Especialidad

                entity.Property(e => e.IdEspecialidad)
                    .IsRequired()
                    .HasField("_especialidadId");

                entity.Navigation(e => e.Especialidad)
                    .HasField("_especialidad");

                entity.HasOne(e => e.Especialidad)
                    .WithMany()
                    .HasForeignKey(e => e.IdEspecialidad)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(new
                {
                    IdPlan = 1,
                    Descripcion = "Plan básico",
                    IdEspecialidad = 1
                });

            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.IdPersona)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdPersona)
                   .IsUnique();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Direccion)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.FechaNacimiento)
                   .IsRequired();

                entity.Property(e => e.IdPlan)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.Legajo)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.Telefono)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.TipoPersona)
                   .IsRequired()
                   .HasMaxLength(30);



                //Relacion con Plan

                entity.Property(e => e.IdPlan)
                    .IsRequired()
                    .HasField("_planId");

                entity.Navigation(e => e.Plan)
                    .HasField("_plan");

                entity.HasOne(e => e.Plan)
                    .WithMany()
                    .HasForeignKey(e => e.IdPlan)
                    .OnDelete(DeleteBehavior.Cascade);

                // Datos iniciales

                entity.HasData(new
                {
                    IdPersona = 1,
                    Apellido = "Admin",
                    Direccion = "Admin 123",
                    Email = "admin@gmail.com",
                    FechaNacimiento = new DateTime(2004, 3, 3),
                    Legajo = 1234,
                    Telefono = "3419999999",
                    TipoPersona = "Administrador",
                    IdPlan = 1
                }
                );

            });

            modelBuilder.Entity<Usuario>(static entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdUsuario)
                   .IsUnique();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nombre)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.Clave)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(50);

                entity.Property(e => e.Habilitado)
                   .IsRequired();

                entity.Property(e => e.NombreUsuario)
                   .IsRequired()
                   .HasMaxLength(40);

                //Relacion con Persona

                entity.Property(e => e.IdPersona)
                    .IsRequired()
                    .HasField("_personaId");

                entity.Navigation(e => e.Persona)
                    .HasField("_persona");

                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona)
                    .OnDelete(DeleteBehavior.Cascade);

                // Datos iniciales

                entity.HasData(new Usuario
                {
                    IdUsuario = 1,
                    Apellido = "Admin",
                    Nombre = "Admin",
                    Clave = "123",
                    Email = "admin@gmail.com",
                    Habilitado = true,
                    NombreUsuario = "admin",
                    IdPersona = 1
                }
                );


            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("Cursos");

                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AnioCalendario)
                    .IsRequired();

                entity.Property(e => e.Cupo)
                    .IsRequired();

                //relacion con materia

                entity.Property(e => e.IdMateria)
                    .IsRequired()
                    .HasField("_materiaId");

                entity.Navigation(e => e.Materia)
                    .HasField("_materia");

                entity.HasOne(e => e.Materia)
                    .WithMany()
                    .HasForeignKey(e => e.IdMateria)
                    .OnDelete(DeleteBehavior.Restrict);

                //relacion con comision

                entity.Property(e => e.IdComision)
                    .IsRequired()
                    .HasField("_comisionId");

                entity.Navigation(e => e.Comision)
                    .HasField("_comision");

                entity.HasOne(e => e.Comision)
                    .WithMany()
                    .HasForeignKey(e => e.IdComision)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.IdMateria)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdMateria)
                   .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.HsSemanales)
                   .IsRequired()
                   .HasMaxLength(30);

                entity.Property(e => e.HsTotales)
                   .IsRequired()
                   .HasMaxLength(30);

                //Relacion con Plan

                entity.Property(e => e.IdPlan)
                    .IsRequired()
                    .HasField("_planId");

                entity.Navigation(e => e.Plan)
                    .HasField("_plan");

                entity.HasOne(e => e.Plan)
                    .WithMany()
                    .HasForeignKey(e => e.IdPlan)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(e => e.IdComision);

                entity.Property(e => e.IdComision)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdComision)
                   .IsUnique();

                entity.Property(e => e.AnioEspecialidad)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Descripcion)
                   .IsRequired()
                   .HasMaxLength(30);


                //Relacion con Plan

                entity.Property(e => e.IdPlan)
                    .IsRequired()
                    .HasField("_planId");

                entity.Navigation(e => e.Plan)
                    .HasField("_plan");

                entity.HasOne(e => e.Plan)
                    .WithMany()
                    .HasForeignKey(e => e.IdPlan)
                    .OnDelete(DeleteBehavior.Cascade);


            });


            modelBuilder.Entity<AlumnoInscripcion>(entity =>
            {
                entity.HasKey(e => e.IdInscripcion);

                entity.Property(e => e.IdInscripcion)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.IdInscripcion)
                   .IsUnique();

                entity.Property(e => e.Condicion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nota)
                   .HasMaxLength(30);


                //Relacion con Persona (Alumno)

                entity.Property(e => e.IdAlumno)
                    .IsRequired()
                    .HasField("_alumnoId");

                entity.Navigation(e => e.Alumno)
                    .HasField("_alumno");

                entity.HasOne(e => e.Alumno)
                    .WithMany()
                    .HasForeignKey(e => e.IdAlumno)
                    .OnDelete(DeleteBehavior.Restrict);

                //Relacion con Curso 

                entity.Property(e => e.IdCurso)
                    .IsRequired()
                    .HasField("_cursoId");

                entity.Navigation(e => e.Curso)
                    .HasField("_curso");

                entity.HasOne(e => e.Curso)
                    .WithMany()
                    .HasForeignKey(e => e.IdCurso)
                    .OnDelete(DeleteBehavior.Cascade);


            });

        }
    }
}