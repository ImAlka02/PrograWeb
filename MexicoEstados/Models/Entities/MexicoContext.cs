using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MexicoEstados.Models.Entities;

public partial class MexicoContext : DbContext
{
    public MexicoContext()
    {
    }

    public MexicoContext(DbContextOptions<MexicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estados> Estados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=mexico;password=juanes1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Estados>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("estados")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Abrev)
                .HasMaxLength(10)
                .HasComment("NOM_ABR - Nombre abreviado de la entidad")
                .HasColumnName("abrev");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasComment("NOM_ENT - Nombre de la entidad")
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
