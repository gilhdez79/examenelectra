using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Model;

public partial class EscuelaMusicContext : DbContext
{
    public EscuelaMusicContext()
    {
    }

    public EscuelaMusicContext(DbContextOptions<EscuelaMusicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Alumnosprofesore> Alumnosprofesores { get; set; }

    public virtual DbSet<Escuela> Escuelas { get; set; }

    public virtual DbSet<ProfesorEscuelaDto> ProfesorEscuelaDtos { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Database=escuelamusica; Uid=developer;pwd=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);

            entity.Property(e => e.IdAlumno).HasColumnName("id_Alumno");
            entity.Property(e => e.Amaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Apaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Alumnosprofesore>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");
        });

        modelBuilder.Entity<Escuela>(entity =>
        {
            entity.HasKey(e => e.IdEscuela);

            entity.ToTable("Escuela");

            entity.Property(e => e.IdEscuela).HasColumnName("idEscuela");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.IdAlumnos).WithMany(p => p.IdEscuelas)
                .UsingEntity<Dictionary<string, object>>(
                    "Alumnosescuela",
                    r => r.HasOne<Alumno>().WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Alumnosescuela_Alumnos"),
                    l => l.HasOne<Escuela>().WithMany()
                        .HasForeignKey("IdEscuela")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Alumnosescuela_Escuela"),
                    j =>
                    {
                        j.HasKey("IdEscuela", "IdAlumno");
                        j.ToTable("Alumnosescuela");
                    });
        });

        modelBuilder.Entity<ProfesorEscuelaDto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProfesorEscuelaDto");

            entity.Property(e => e.Alumno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Escuela)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Profesor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.IdProfesor);

            entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdEscuelas).WithMany(p => p.Idprofesors)
                .UsingEntity<Dictionary<string, object>>(
                    "Profesorescuela",
                    r => r.HasOne<Escuela>().WithMany()
                        .HasForeignKey("IdEscuela")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Profesorescuela_Escuela"),
                    l => l.HasOne<Profesore>().WithMany()
                        .HasForeignKey("Idprofesor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Profesorescuela_Profesores"),
                    j =>
                    {
                        j.HasKey("Idprofesor", "IdEscuela");
                        j.ToTable("Profesorescuela");
                        j.IndexerProperty<int>("Idprofesor").HasColumnName("idprofesor");
                        j.IndexerProperty<int>("IdEscuela").HasColumnName("idEscuela");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
