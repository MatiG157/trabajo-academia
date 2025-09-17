using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;

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

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdMateria)
                    .IsRequired();

                entity.Property(e => e.IdComision)
                    .IsRequired();

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
                    .HasForeignKey(e => e.IdMateria);

                //relacion con comision

                entity.Property(e => e.IdComision)
                    .IsRequired()
                    .HasField("_comisionId");

                entity.Navigation(e => e.Comision)
                    .HasField("_comision");

                entity.HasOne(e => e.Comision)
                    .WithMany()
                    .HasForeignKey(e => e.IdMateria);
            });

            modelBuilder.Entity<Usuario>(entity =>
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
                    .HasForeignKey(e => e.IdPersona);

                // Datos iniciales
                
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

                entity.Property(e => e.IdPlan)
                   .IsRequired()
                   .HasMaxLength(50);

                //Relacion con Plan

                /*entity.Property(e => e.IdPersona)
                    .IsRequired()
                    .HasField("_personaId");

                entity.Navigation(e => e.Persona)
                    .HasField("_persona");

                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona);*/

            });


            //Comisión

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

                entity.Property(e => e.IdPlan)
                   .IsRequired()
                   .HasMaxLength(30);


                //Relacion con Plan

                /*entity.Property(e => e.IdPersona)
                    .IsRequired()
                    .HasField("_personaId");

                entity.Navigation(e => e.Persona)
                    .HasField("_persona");

                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona);*/

                
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
                   .IsRequired()
                   .HasMaxLength(30);

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

                /*entity.Property(e => e.IdPersona)
                    .IsRequired()
                    .HasField("_personaId");

                entity.Navigation(e => e.Persona)
                    .HasField("_persona");

                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona);*/


            });

        }
    }
}