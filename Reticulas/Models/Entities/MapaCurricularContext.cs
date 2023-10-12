﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reticulas.Models.Entities;

public partial class MapaCurricularContext : DbContext
{
    public MapaCurricularContext()
    {
    }

    public MapaCurricularContext(DbContextOptions<MapaCurricularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carreras> Carreras { get; set; }

    public virtual DbSet<Materias> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=mapa_curricular;user=root;password=juanes1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Carreras>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("carreras")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.Clave, "Clave_UNIQUE").IsUnique();

            entity.Property(e => e.Clave)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Plan)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Materias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("materias");

            entity.HasIndex(e => e.IdCarrera, "fkmat_idx1");

            entity.Property(e => e.Clave)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Nombre).HasMaxLength(65);

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Materias)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkmat");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
