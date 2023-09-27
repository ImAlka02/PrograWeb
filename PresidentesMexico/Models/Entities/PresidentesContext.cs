using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PresidentesMexico.Models.Entitis;

public partial class PresidentesContext : DbContext
{
    public PresidentesContext()
    {
    }

    public PresidentesContext(DbContextOptions<PresidentesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estadorepublica> Estadorepublica { get; set; }

    public virtual DbSet<Partidopolitico> Partidopolitico { get; set; }

    public virtual DbSet<Presidente> Presidente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=presidentes;password=juanes1;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Estadorepublica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estadorepublica");

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Partidopolitico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partidopolitico");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Presidente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("presidente");

            entity.HasIndex(e => e.IdEstadoRepublica, "IdEstadoRepublica_idx");

            entity.HasIndex(e => e.IdPartidoPolitico, "IdPartidoPolitico_idx");

            entity.Property(e => e.CiudadNacimiento).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Ocupacion).HasColumnType("text");

            entity.HasOne(d => d.IdEstadoRepublicaNavigation).WithMany(p => p.Presidente)
                .HasForeignKey(d => d.IdEstadoRepublica)
                .HasConstraintName("IdEstadoRepublica");

            entity.HasOne(d => d.IdPartidoPoliticoNavigation).WithMany(p => p.Presidente)
                .HasForeignKey(d => d.IdPartidoPolitico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdPartidoPolitico");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
