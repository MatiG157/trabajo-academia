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
    internal class TPIContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Persona> Personas { get; set; }

        internal TPIContext()
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
                    .HasField("_idPersona");

                entity.HasOne(e => e.Persona)
                    .WithMany()
                    .HasForeignKey(e => e.IdPersona);

                // Datos iniciales
                entity.HasData(
                    new Usuario(1, "jperez", "clave123", true, "Juan", "Pérez", "juan.perez@email.com", false, 101),
                    new Usuario(2, "mgomez", "maria456", true, "María", "Gómez", "maria.gomez@email.com", true, 102),
                    new Usuario(3, "clopez", "carlos789", false, "Carlos", "López", "carlos.lopez@email.com", false, 103),
                    new Usuario(4, "amartinez", "ana321", true, "Ana", "Martínez", "ana.martinez@email.com", true, 104),
                    new Usuario(5, "lfernandez", "lucia654", true, "Lucía", "Fernández", "lucia.fernandez@email.com", false, 105),
                    new Usuario(6, "dramirez", "diego987", false, "Diego", "Ramírez", "diego.ramirez@email.com", true, 106)
                );
            });
        }
    }
}