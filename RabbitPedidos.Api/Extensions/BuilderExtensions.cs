using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Api.Data;
using RabbitPedidos.Api.Repository;
using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Api.Services;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.Commons;

namespace RabbitPedidos.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        Configurations.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PedidosDbContext>(options =>
        {
            options.UseMySQL(Configurations.ConnectionString);
        });
    }

    public static void AddRepositories(this WebApplicationBuilder builder1)
    {
        builder1.Services.AddTransient<IPedidoRepository, PedidoRepository>();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IPedidoService, PedidoService>();
    }
}
