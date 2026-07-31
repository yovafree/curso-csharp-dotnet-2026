using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo1.Models;

public partial class CursoDbContext : DbContext
{
    public CursoDbContext()
    {
    }

    public CursoDbContext(DbContextOptions<CursoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Notum> Nota { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=curso_db;User=db_user;Password=Password1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.CodAutor).HasName("PRIMARY");

            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(6)
                .HasDefaultValueSql("'0001-01-01 00:00:00.000000'");
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CodCurso).HasName("PRIMARY");

            entity.ToTable("curso");

            entity.Property(e => e.CodCurso).HasColumnName("cod_curso");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnName("estado");
            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fec_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.CodEstudiante).HasName("PRIMARY");

            entity.ToTable("estudiante");

            entity.HasIndex(e => e.CodCurso, "fk_curso_estudiante_idx");

            entity.Property(e => e.CodEstudiante).HasColumnName("cod_estudiante");
            entity.Property(e => e.CodCurso).HasColumnName("cod_curso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodCursoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.CodCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_curso_estudiante");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.CodLibro).HasName("PRIMARY");

            entity.HasIndex(e => e.AutorCodAutor, "IX_Libros_AutorCodAutor");

            entity.Property(e => e.FechaPublicacion).HasMaxLength(6);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.AutorCodAutorNavigation).WithMany(p => p.Libros).HasForeignKey(d => d.AutorCodAutor);
        });

        modelBuilder.Entity<Notum>(entity =>
        {
            entity.HasKey(e => e.CodNota).HasName("PRIMARY");

            entity.ToTable("nota");

            entity.HasIndex(e => e.CodEstudiante, "fk_curso_estudiante_idx");

            entity.HasIndex(e => e.CodCurso, "fk_curso_nota_idx");

            entity.Property(e => e.CodNota).HasColumnName("cod_nota");
            entity.Property(e => e.CodCurso).HasColumnName("cod_curso");
            entity.Property(e => e.CodEstudiante).HasColumnName("cod_estudiante");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnName("estado");
            entity.Property(e => e.Nota).HasColumnName("nota");

            entity.HasOne(d => d.CodCursoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.CodCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_curso_nota");

            entity.HasOne(d => d.CodEstudianteNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.CodEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiante_nota");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.CodPrestamo).HasName("PRIMARY");

            entity.HasIndex(e => e.LibroCodLibro, "IX_Prestamos_LibroCodLibro");

            entity.Property(e => e.FechaDevolucion).HasMaxLength(6);
            entity.Property(e => e.FechaPrestamo).HasMaxLength(6);

            entity.HasOne(d => d.LibroCodLibroNavigation).WithMany(p => p.Prestamos).HasForeignKey(d => d.LibroCodLibro);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
