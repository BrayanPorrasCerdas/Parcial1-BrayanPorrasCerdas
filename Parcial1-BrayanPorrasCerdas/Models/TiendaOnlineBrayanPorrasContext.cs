using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parcial1_BrayanPorrasCerdas.Models;

public partial class TiendaOnlineBrayanPorrasContext : DbContext
{
    public TiendaOnlineBrayanPorrasContext()
    {
    }

    public TiendaOnlineBrayanPorrasContext(DbContextOptions<TiendaOnlineBrayanPorrasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CaracteristicaProducto> CaracteristicaProductos { get; set; }

    public virtual DbSet<CarritoCompra> CarritoCompras { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<CategoriaPromocion> CategoriaPromocions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConfiguracionProducto> ConfiguracionProductos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<DireccionCliente> DireccionClientes { get; set; }

    public virtual DbSet<EstadoOrdenCompra> EstadoOrdenCompras { get; set; }

    public virtual DbSet<ItemCarritoCompra> ItemCarritoCompras { get; set; }

    public virtual DbSet<ItemOrdenCompra> ItemOrdenCompras { get; set; }

    public virtual DbSet<ItemProducto> ItemProductos { get; set; }

    public virtual DbSet<MetodoEnvio> MetodoEnvios { get; set; }

    public virtual DbSet<MetodoPagoCliente> MetodoPagoClientes { get; set; }

    public virtual DbSet<OpcionCaracteristicaProducto> OpcionCaracteristicaProductos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Promocion> Promocions { get; set; }

    public virtual DbSet<ReseñaCliente> ReseñaClientes { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CaracteristicaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristica).HasName("PK__Caracter__8761175C4D43BD76");

            entity.ToTable("CaracteristicaProducto");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.CaracteristicaProductos)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Caracteri__IdCat__0E6E26BF");
        });

        modelBuilder.Entity<CarritoCompra>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__CarritoC__8B4A618CDD6F3B55");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CarritoCompras)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoCo__IdCli__619B8048");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A105BFF966F");

            entity.ToTable("CategoriaProducto");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCategoria).HasMaxLength(132);

            entity.HasOne(d => d.IdCategoriaPadreNavigation).WithMany(p => p.InverseIdCategoriaPadreNavigation)
                .HasForeignKey(d => d.IdCategoriaPadre)
                .HasConstraintName("FK__Categoria__IdCat__7A672E12");
        });

        modelBuilder.Entity<CategoriaPromocion>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A105ADDBDAA");

            entity.ToTable("CategoriaPromocion");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdPromocionNavigation).WithMany(p => p.CategoriaPromocions)
                .HasForeignKey(d => d.IdPromocion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Categoria__IdPro__74AE54BC");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC075DA76590");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Correo, "UQ__Cliente__60695A191ACADAD7").IsUnique();

            entity.Property(e => e.Apellidos).HasMaxLength(255);
            entity.Property(e => e.Clave).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<ConfiguracionProducto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ConfiguracionProducto");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdItemProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdItemProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Configura__IdIte__17036CC0");

            entity.HasOne(d => d.IdOpcionCaracteristicaProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdOpcionCaracteristicaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Configura__IdOpc__17F790F9");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Direccio__3214EC07662CDD68");

            entity.ToTable("Direccion");

            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.DireccionExacta).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<DireccionCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DireccionCliente");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany()
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Direccion__IdCli__46E78A0C");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany()
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Direccion__IdDir__47DBAE45");
        });

        modelBuilder.Entity<EstadoOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdEstadoOrden).HasName("PK__EstadoOr__F2E6940E5D5575E5");

            entity.ToTable("EstadoOrdenCompra");

            entity.Property(e => e.Estado).HasMaxLength(64);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ItemCarritoCompra>(entity =>
        {
            entity.HasKey(e => e.IdItemCarrito).HasName("PK__ItemCarr__B3FA1501CB1C2B1E");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.ItemCarritoCompras)
                .HasForeignKey(d => d.IdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemCarri__IdCar__6754599E");
        });

        modelBuilder.Entity<ItemOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdItemOrden).HasName("PK__ItemOrde__37B3621802C0607E");

            entity.ToTable("ItemOrdenCompra");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdItemProductoNavigation).WithMany(p => p.ItemOrdenCompras)
                .HasForeignKey(d => d.IdItemProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemOrden__IdIte__245D67DE");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.ItemOrdenCompras)
                .HasForeignKey(d => d.IdOrdenCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemOrden__IdOrd__25518C17");
        });

        modelBuilder.Entity<ItemProducto>(entity =>
        {
            entity.HasKey(e => e.IdItemProducto).HasName("PK__ItemProd__FD1D03F699A7EBFD");

            entity.ToTable("ItemProducto");

            entity.Property(e => e.CodigoBarras).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UrlImagen).HasMaxLength(1024);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ItemProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemProdu__IdPro__08B54D69");
        });

        modelBuilder.Entity<MetodoEnvio>(entity =>
        {
            entity.HasKey(e => e.IdMetodoEnvio).HasName("PK__MetodoEn__67A95A9C4D083583");

            entity.ToTable("MetodoEnvio");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(132);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<MetodoPagoCliente>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__MetodoPa__6F49A9BE7A9C60DB");

            entity.ToTable("MetodoPagoCliente");

            entity.Property(e => e.Cuenta).HasMaxLength(24);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaExpira).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreProveedor).HasMaxLength(255);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.MetodoPagoClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MetodoPag__IdCli__5812160E");
        });

        modelBuilder.Entity<OpcionCaracteristicaProducto>(entity =>
        {
            entity.HasKey(e => e.IdOpcionCaracteristica).HasName("PK__OpcionCa__9A4E4B6D28D20ED0");

            entity.ToTable("OpcionCaracteristicaProducto");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Valor).HasMaxLength(255);

            entity.HasOne(d => d.IdCaracteristicaProductoNavigation).WithMany(p => p.OpcionCaracteristicaProductos)
                .HasForeignKey(d => d.IdCaracteristicaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OpcionCar__IdCar__1332DBDC");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra).HasName("PK__OrdenCom__685E464B9567CE2D");

            entity.ToTable("OrdenCompra");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoOrden).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenComp__IdCli__1DB06A4F");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pais__3214EC07576584E3");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(132);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210BAA2DB75");

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreProducto).HasMaxLength(132);
            entity.Property(e => e.UrlImagen).HasMaxLength(1024);

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__IdCate__01142BA1");
        });

        modelBuilder.Entity<Promocion>(entity =>
        {
            entity.HasKey(e => e.IdPromocion).HasName("PK__Promocio__35F6C2A53850BECD");

            entity.ToTable("Promocion");

            entity.Property(e => e.Descripcion).HasMaxLength(132);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinaliza).HasColumnType("datetime");
            entity.Property(e => e.FechaInicia).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCorto).HasMaxLength(64);
            entity.Property(e => e.PorcentajeDescuento).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<ReseñaCliente>(entity =>
        {
            entity.HasKey(e => e.IdResena).HasName("PK__ReseñaCl__A53BB7F88E70C916");

            entity.ToTable("ReseñaCliente");

            entity.Property(e => e.Comentario).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ReseñaClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReseñaCli__IdCli__52593CB8");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago).HasName("PK__TipoPago__EB0AA9E7374F1027");

            entity.ToTable("TipoPago");

            entity.Property(e => e.Descripcion).HasMaxLength(132);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
