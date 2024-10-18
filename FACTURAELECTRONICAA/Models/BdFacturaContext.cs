using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FACTURAELECTRONICAA.Models;

public partial class BdFacturaContext : DbContext
{
    public BdFacturaContext()
    {
    }

    public BdFacturaContext(DbContextOptions<BdFacturaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    public virtual DbSet<ProductoVentum> ProductoVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= LAPTOP-C07V5HRN\\SQLEXPRESS;Database=BD_FACTURA; Integrated security=true;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacturaCabecera>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__FacturaC__5C024805E9CBD0E2");

            entity.ToTable("FacturaCabecera");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.DireccionCliente).HasMaxLength(255);
            entity.Property(e => e.FormaPago)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NumeroFactura).HasMaxLength(20);
            entity.Property(e => e.Observacion).HasMaxLength(255);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.Ruc)
                .HasMaxLength(15)
                .HasColumnName("RUC");
            entity.Property(e => e.TipoMoneda).HasMaxLength(10);
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__FacturaD__6E19D6FAAC5D4A54");

            entity.ToTable("FacturaDetalle");

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.Anticipos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descuentos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Igv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IGV");
            entity.Property(e => e.ProductoVentaId).HasColumnName("ProductoVentaID");
            entity.Property(e => e.SubTotalVentas).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__FacturaDe__Factu__3C69FB99");

            entity.HasOne(d => d.ProductoVenta).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ProductoVentaId)
                .HasConstraintName("FK__FacturaDe__Produ__3D5E1FD2");
        });

        modelBuilder.Entity<ProductoVentum>(entity =>
        {
            entity.HasKey(e => e.ProductoVentaId).HasName("PK__Producto__82CC39D21660426D");

            entity.Property(e => e.ProductoVentaId).HasColumnName("ProductoVentaID");
            entity.Property(e => e.CodigoProducto).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnidadMedida).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
