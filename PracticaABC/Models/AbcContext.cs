using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaABC.Models;

public partial class AbcContext : DbContext
{
    public AbcContext()
    {
    }

    public AbcContext(DbContextOptions<AbcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estiba> Estibas { get; set; }

    public virtual DbSet<ProductoDistribucion> ProductoDistribucions { get; set; }

    public virtual DbSet<TipoDistribucion> TipoDistribucions { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estiba>(entity =>
        {
            entity.HasKey(e => e.IdEstiba).HasName("PK__Estibas__F1E2F0199281AF3C");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductoDistribucion>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892105D3BF63C");

            entity.ToTable("ProductoDistribucion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioMayor).HasColumnName("Precio_Mayor");
            entity.Property(e => e.PrecioMenor).HasColumnName("Precio_Menor");

            entity.HasOne(d => d.IdDistNavigation).WithMany(p => p.ProductoDistribucions)
                .HasForeignKey(d => d.IdDist)
                .HasConstraintName("FK_ProductoDistribucion_TipoDistribucion");

            entity.HasOne(d => d.IdEstibaNavigation).WithMany(p => p.ProductoDistribucions)
                .HasForeignKey(d => d.IdEstiba)
                .HasConstraintName("FK_ProductoDistribucion_Estibas");

            entity.HasOne(d => d.IdTipoProdNavigation).WithMany(p => p.ProductoDistribucions)
                .HasForeignKey(d => d.IdTipoProd)
                .HasConstraintName("FK_ProductoDistribucion_TipoProducto");
        });

        modelBuilder.Entity<TipoDistribucion>(entity =>
        {
            entity.HasKey(e => e.IdDist).HasName("PK__TipoDist__F1680331FF27D11F");

            entity.ToTable("TipoDistribucion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.IdTipoProd).HasName("PK__TipoProd__E8571A5694BA0F57");

            entity.ToTable("TipoProducto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__645723A62ECF2609");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
