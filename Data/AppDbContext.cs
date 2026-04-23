using System;
using Microsoft.EntityFrameworkCore;
using Delivery.Entidades;

namespace Delivery.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Repartidor> Repartidores { get; set; }
    public DbSet<Local> Locales { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Detalle_Pedido> DetallePedidos { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
            .WithMany()
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Repartidor)
            .WithMany()
            .HasForeignKey(p => p.RepartidorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Local)
            .WithMany()
            .HasForeignKey(p => p.LocalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Detalle_Pedido>()
            .HasOne(d => d.Pedido)
            .WithMany()
            .HasForeignKey(d => d.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Detalle_Pedido>()
            .HasOne(d => d.Producto)
            .WithMany()
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
