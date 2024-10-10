using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace capaEntidad.Models;

public partial class TortilleriaContext : DbContext
{
    public TortilleriaContext()
    {
    }

    public TortilleriaContext(DbContextOptions<TortilleriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clasesproducto> Clasesproductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detallespedido> Detallespedidos { get; set; }

    public virtual DbSet<Egreso> Egresos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Rutascliente> Rutasclientes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=tortilleria;user=root;password=dragonBALL34", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clasesproducto>(entity =>
        {
            entity.HasKey(e => e.IdClaseProducto).HasName("PRIMARY");

            entity.ToTable("clasesproducto");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.Direccion).HasMaxLength(240);
            entity.Property(e => e.NombreCliente).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoCliente).HasColumnType("enum('REGULAR','NEGOCIO')");
        });

        modelBuilder.Entity<Detallespedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PRIMARY");

            entity.ToTable("detallespedido");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.Cantidad).HasPrecision(10, 2);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallespedido_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallespedido_ibfk_2");
        });

        modelBuilder.Entity<Egreso>(entity =>
        {
            entity.HasKey(e => e.IdEgreso).HasName("PRIMARY");

            entity.ToTable("egresos");

            entity.HasIndex(e => e.IdUsuario, "IdUsuario");

            entity.Property(e => e.Categoria).HasColumnType("enum('proveedores','sueldos','mantenimiento','otros')");
            entity.Property(e => e.Concepto).HasMaxLength(255);
            entity.Property(e => e.FechaEgreso)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Monto).HasPrecision(10, 2);
            entity.Property(e => e.Notas).HasColumnType("text");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Egresos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("egresos_ibfk_1");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PRIMARY");

            entity.ToTable("inventario");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.CantidadDisponible).HasPrecision(10, 2);
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_ibfk_1");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.VentaId, "VentaId");

            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.MetodoPago).HasColumnType("enum('efectivo','tarjeta','credito','transferencia')");
            entity.Property(e => e.MontoPagado).HasPrecision(10, 2);

            entity.HasOne(d => d.Venta).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_ibfk_1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.IdCliente, "IdCliente");

            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'pendiente'")
                .HasColumnType("enum('pendiente','pagado','cancelado')");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Pagado)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.ClaseProductoId, "ClaseProductoId");

            entity.HasIndex(e => e.ProveedorId, "ProveedorId");

            entity.Property(e => e.LoteProducto).HasMaxLength(100);
            entity.Property(e => e.NombreProducto).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.ClaseProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ClaseProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_ibfk_1");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_ibfk_2");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.NombreProveedor).HasMaxLength(200);
        });

        modelBuilder.Entity<Rutascliente>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("PRIMARY");

            entity.ToTable("rutasclientes");

            entity.HasIndex(e => e.IdCliente, "IdCliente");

            entity.Property(e => e.Distancia).HasPrecision(10, 2);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.PuntoDestino).HasMaxLength(255);
            entity.Property(e => e.PuntoInicio).HasMaxLength(255);
            entity.Property(e => e.TiempoEstimado).HasColumnType("time");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Rutasclientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("rutasclientes_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.HashPassword).HasMaxLength(255);
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);
            entity.Property(e => e.Rol).HasColumnType("enum('admin','vendedor')");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.TotalVenta).HasPrecision(10, 2);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("ventas_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("ventas_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
