using System;
using System.Collections.Generic;
using Flowers.Models;
using Microsoft.EntityFrameworkCore;

namespace Flowers.Repository.DBContext;

public partial class FlowersB2cContext : DbContext
{
    public FlowersB2cContext()
    {
    }

    public FlowersB2cContext(DbContextOptions<FlowersB2cContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<ListaDeseo> ListaDeseos { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<OrdenItem> OrdenItems { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CarritoId).HasName("PK__Carrito__8647FB09EF7ECC1E");

            entity.ToTable("Carrito");

            entity.Property(e => e.CarritoId).HasColumnName("carrito_id");
            entity.Property(e => e.CarritoCantidad).HasColumnName("carrito_cantidad");
            entity.Property(e => e.CarritoCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("carrito_created_at");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carrito_producto_id_foreign");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carrito_usuario_id_foreign");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__DB875A4F976F9041");

            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.CategoriaCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("categoria_created_at");
            entity.Property(e => e.CategoriaNombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("categoria_nombre");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.EnvioId).HasName("PK__Envio__C67B9A038A3ED919");

            entity.ToTable("Envio");

            entity.Property(e => e.EnvioId).HasColumnName("envio_id");
            entity.Property(e => e.EnvioCiudad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("envio_ciudad");
            entity.Property(e => e.EnvioCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("envio_created_at");
            entity.Property(e => e.EnvioDepartamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("envio_departamento");
            entity.Property(e => e.EnvioDescripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("envio_descripcion");
            entity.Property(e => e.EnvioDireccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("envio_direccion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Envios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("envio_usuario_id_foreign");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.FotoId).HasName("PK__Foto__9FE012AA38036F5A");

            entity.ToTable("Foto");

            entity.Property(e => e.FotoId).HasColumnName("foto_id");
            entity.Property(e => e.FotoCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("foto_created_at");
            entity.Property(e => e.FotoPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("foto_path");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foto_producto_id_foreign");
        });

        modelBuilder.Entity<ListaDeseo>(entity =>
        {
            entity.HasKey(e => e.ListaDeseosId).HasName("PK__Lista_De__F635230A7D25B30A");

            entity.ToTable("Lista_Deseos");

            entity.Property(e => e.ListaDeseosId).HasColumnName("lista_deseos_id");
            entity.Property(e => e.ListaDeseosCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lista_deseos_created_at");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.ListaDeseos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lista_deseos_producto_id_foreign");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ListaDeseos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lista_deseos_usuario_id_foreign");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__Orden__F983C4DA9B79D6B9");

            entity.ToTable("Orden");

            entity.Property(e => e.OrdenId).HasColumnName("orden_id");
            entity.Property(e => e.EnvioId).HasColumnName("envio_id");
            entity.Property(e => e.OrdenCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Orden_created_at");
            entity.Property(e => e.OrdenPrecio)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("orden_precio");
            entity.Property(e => e.PagoId).HasColumnName("pago_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Envio).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orden_envio_id_foreign");

            entity.HasOne(d => d.Pago).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.PagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orden_pago_id_foreign");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orden_usuario_id_foreign");
        });

        modelBuilder.Entity<OrdenItem>(entity =>
        {
            entity.HasKey(e => e.OrdenItemId).HasName("PK__Orden_It__A9542D76B7AC527F");

            entity.ToTable("Orden_Items");

            entity.Property(e => e.OrdenItemId).HasColumnName("orden_item_id");
            entity.Property(e => e.OrdenId).HasColumnName("orden_id");
            entity.Property(e => e.OrdenItemCantidad).HasColumnName("Orden_Item_cantidad");
            entity.Property(e => e.OrdenItemPrecio)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Orden_Item_precio");
            entity.Property(e => e.OrdenItemsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Orden_Items_created_at");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenItems)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orden_items_orden_id_foreign");

            entity.HasOne(d => d.Producto).WithMany(p => p.OrdenItems)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orden_items_producto_id_foreign");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pago__FFF0A58E3E26A1F8");

            entity.ToTable("Pago");

            entity.Property(e => e.PagoId).HasColumnName("pago_id");
            entity.Property(e => e.PagoCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("pago_created_at");
            entity.Property(e => e.PagoMetodo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pago_metodo");
            entity.Property(e => e.PagoMonto)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("pago_monto");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_usuario_id_foreign");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__FB5CEEEC8F1D1456");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.ProductoCodigo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("producto_codigo");
            entity.Property(e => e.ProductoCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("producto_created_at");
            entity.Property(e => e.ProductoDescripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("producto_descripcion");
            entity.Property(e => e.ProductoNombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("producto_nombre");
            entity.Property(e => e.ProductoPrecio)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("producto_precio");
            entity.Property(e => e.ProductoStock).HasColumnName("producto_stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_categoria_id_foreign");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2ED7D2AFEAA9C5DF");

            entity.HasIndex(e => e.UsuarioEmail, "usuarios_email_unique").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.UsuarioApellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_apellido");
            entity.Property(e => e.UsuarioCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("usuario_created_at");
            entity.Property(e => e.UsuarioDireccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_direccion");
            entity.Property(e => e.UsuarioEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_email");
            entity.Property(e => e.UsuarioNombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_nombre");
            entity.Property(e => e.UsuarioPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_password");
            entity.Property(e => e.UsuarioRol)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_rol");
            entity.Property(e => e.UsuarioTelefono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
