using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProrgamaNiños.Models;

public partial class ProgramaNinosContext : DbContext
{
    public ProgramaNinosContext()
    {
    }

    public ProgramaNinosContext(DbContextOptions<ProgramaNinosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Infantes> Infantes { get; set; }

    public virtual DbSet<Vmcatorceaños> Vmcatorceaños { get; set; }

    public virtual DbSet<Vmcumplenhoy> Vmcumplenhoy { get; set; }

    public virtual DbSet<Vmmenoresde15> Vmmenoresde15 { get; set; }

    public virtual DbSet<Vwcumplemes> Vwcumplemes { get; set; }

    public virtual DbSet<Vwestadisticaciudades> Vwestadisticaciudades { get; set; }

    public virtual DbSet<Vwmayoresde15> Vwmayoresde15 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=ProgramaNinos;port=3307", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Infantes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("infantes");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .HasColumnName("ciudad");
            entity.Property(e => e.Domicilio)
                .HasDefaultValueSql("'desconocido'")
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vmcatorceaños>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vmcatorceaños");

            entity.Property(e => e.Domicilio)
                .HasDefaultValueSql("'desconocido'")
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vmcumplenhoy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vmcumplenhoy");

            entity.Property(e => e.Domicilio)
                .HasDefaultValueSql("'desconocido'")
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vmmenoresde15>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vmmenoresde15");

            entity.Property(e => e.Domicilio)
                .HasDefaultValueSql("'desconocido'")
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vwcumplemes>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwcumplemes");

            entity.Property(e => e.Domicilio)
                .HasDefaultValueSql("'desconocido'")
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vwestadisticaciudades>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwestadisticaciudades");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .HasColumnName("ciudad");
            entity.Property(e => e.Count)
                .HasColumnType("bigint(21)")
                .HasColumnName("COUNT(*)");
        });

        modelBuilder.Entity<Vwmayoresde15>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmayoresde15");

            entity.Property(e => e.Domicilio)
                .HasDefaultValueSql("'desconocido'")
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
