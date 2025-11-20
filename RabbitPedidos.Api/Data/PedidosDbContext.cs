using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Shared.Models;
using System.Reflection;

namespace RabbitPedidos.Api.Data;

public class PedidosDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
