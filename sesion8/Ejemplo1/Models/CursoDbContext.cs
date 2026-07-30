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

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Notum> Nota { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=curso_db;User=db_user;Password=Password1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
