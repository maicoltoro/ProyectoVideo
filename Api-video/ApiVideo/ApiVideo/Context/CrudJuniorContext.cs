using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiVideo.Models.STI;

namespace ApiVideo.Context
{
    public partial class CrudJuniorContext : DbContext
    {
        public CrudJuniorContext()
        {
        }

        public CrudJuniorContext(DbContextOptions<CrudJuniorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agente> Agentes { get; set; } = null!;
        public virtual DbSet<Asesor> Asesors { get; set; } = null!;
        public virtual DbSet<Dato> Datos { get; set; } = null!;
        public virtual DbSet<GuardarVideo> GuardarVideos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv-datamart1.co.jazztel.com\\MADRID2;Database=CrudJunior; User Id=iceberg; Password=3T1C0l0mb142022*; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agente>(entity =>
            {
                entity.HasKey(e => e.Documento);

                entity.Property(e => e.Documento).HasMaxLength(15);

                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombres).HasMaxLength(100);
            });

            modelBuilder.Entity<Asesor>(entity =>
            {
                entity.HasKey(e => e.IdAsesor);

                entity.ToTable("Asesor");

                entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dato>(entity =>
            {
                entity.ToTable("datos");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .HasColumnName("NOMBRES");
            });

            modelBuilder.Entity<GuardarVideo>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.Property(e => e.NombreVideo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NombreVIdeo");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fecha");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
